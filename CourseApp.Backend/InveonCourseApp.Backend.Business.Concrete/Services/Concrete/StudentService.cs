namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IAccountService accountService;
        private readonly IRabbitmqPublisherService rabbitmqPublisherService;
        private readonly IStudentRepository studentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<StudentService> logger;
        public StudentService(IAccountService accountService, IRabbitmqPublisherService rabbitmqPublisherService, IStudentRepository studentRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<StudentService> logger)
        {
            this.accountService = accountService;
            this.rabbitmqPublisherService = rabbitmqPublisherService;
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<StudentDto>> AddAsync(StudentAddDto studentAddDto)
        {
            if (await accountService.AnyAsync(identityUser => identityUser.Email == studentAddDto.Email))
                return new ErrorDataResult<StudentDto>(stringLocalizer[Message.Account_Email_Has_Already_Existed]);

            if (await accountService.AnyAsync(identityUser => identityUser.UserName == studentAddDto.Username))
                return new ErrorDataResult<StudentDto>(stringLocalizer[Message.Account_Username_Has_Already_Existed]);

            var identityUser = new IdentityUser
            {
                EmailConfirmed = false,
                Email = studentAddDto.Email,
                UserName = studentAddDto.Username,
                NormalizedEmail = studentAddDto.Email.ToUpperInvariant(),
                NormalizedUserName = studentAddDto.Username.ToUpperInvariant()
            };
            identityUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(identityUser, studentAddDto.Password);

            IDataResult<StudentDto> dataResult = new ErrorDataResult<StudentDto>();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var identityResult = await accountService.SignUpAsync(identityUser, Role.Student);
                    if (!identityResult.Succeeded)
                    {
                        logger.LogError($"{stringLocalizer[Message.Student_Could_Not_Added]} : {identityResult.Errors.ToList()}");
                        dataResult = new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Could_Not_Added]);
                        await transactionScope.RollbackAsync();
                        return;
                    }

                    var student = new Student { IdentityId = Guid.Parse(identityUser.Id) };
                    studentAddDto.Adapt(student);

                    await studentRepository.AddAsync(student);
                    await unitOfWork.SaveChangesAsync();

                    var emailForNewStudentDto = new EmailForNewStudentDto
                    {
                        To = $"{student.Name} {student.Surname}",
                        EmailTo = student.Email
                    };

                    rabbitmqPublisherService.EnqueueModel<EmailForNewStudentDto>(emailForNewStudentDto, QueueName.NewStudent);

                    dataResult = new SuccessDataResult<StudentDto>(student.Adapt<StudentDto>(), $"{stringLocalizer[Message.Student_Was_Added_Successfully]}\n{stringLocalizer[Message.Rabbitmq_StartSendingEmailProcess_Was_Successful]}");
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Student_Could_Not_Added]} : {exception.Message}");
                    dataResult = new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Could_Not_Added]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return dataResult;
        }

        public async Task<IDataResult<StudentDto>> GetByEmailAsync(string email) =>
            await studentRepository.GetFirstOrDefaultAsync(student => student.Email == email) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ByEmail]) : new SuccessDataResult<StudentDto>((await studentRepository.GetFirstOrDefaultAsync(student => student.Email == email)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ByEmail]);

        public async Task<IDataResult<StudentDto>> GetByIdAsync(Guid id) =>
            await studentRepository.GetByIdAsync(id) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ById]) : new SuccessDataResult<StudentDto>((await studentRepository.GetByIdAsync(id)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ById]);

        public async Task<IDataResult<StudentDto>> GetByIdentityIdAsync(Guid identityId) =>
            await studentRepository.GetByIdentityIdAsync(identityId) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]) : new SuccessDataResult<StudentDto>((await studentRepository.GetByIdentityIdAsync(identityId)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ByIdentityId]);
    }
}