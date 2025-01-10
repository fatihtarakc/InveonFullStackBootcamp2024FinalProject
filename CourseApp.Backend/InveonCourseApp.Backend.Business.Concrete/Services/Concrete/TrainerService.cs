namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class TrainerService : ITrainerService
    {
        private readonly IAccountService accountService;
        private readonly IRabbitmqPublisherService rabbitmqPublisherService;
        private readonly ITrainerRepository trainerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<TrainerService> logger;
        public TrainerService(IAccountService accountService, IRabbitmqPublisherService rabbitmqPublisherService, ITrainerRepository trainerRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<TrainerService> logger)
        {
            this.accountService = accountService;
            this.rabbitmqPublisherService = rabbitmqPublisherService;
            this.trainerRepository = trainerRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<TrainerDto>> AddAsync(TrainerAddDto trainerAddDto)
        {
            if (!(await accountService.AnyAsync(identityUser => identityUser.Email == trainerAddDto.Email))) return new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Account_Was_Not_Found]);

            if (!(await trainerRepository.AnyAsync(trainer => trainer.Email == trainerAddDto.Email))) return new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Has_Already_Been_Existed]);

            IDataResult<TrainerDto> dataResult = new ErrorDataResult<TrainerDto>();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);

                try
                {
                    bool status = HelperAge.TrainerControl(trainerAddDto.Birthdate);
                    if (!status)
                    {
                        dataResult = new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Student_Can_Not_Be_Trainer]);
                        return;
                    }

                    var identityUser = await accountService.FindByEmailAsync(trainerAddDto.Email);
                    if (identityUser is null)
                    {
                        dataResult = new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Account_Was_Not_Found]);
                        return;
                    }

                    var identityResult = await accountService.AddToRoleAsync(identityUser, Role.Trainer);
                    if (!identityResult.Succeeded)
                    {
                        logger.LogError($"{stringLocalizer[Message.Student_Could_Not_Added]} : {identityResult.Errors.ToList()}");
                        dataResult = new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Student_Trainer_Role_Could_Not_Be_Added]);
                        await transactionScope.RollbackAsync();
                        return;
                    }

                    var trainer = new Trainer { IdentityId = Guid.Parse(identityUser.Id) };
                    trainer.CreatedBy = identityUser.Id;
                    trainerAddDto.Adapt(trainer);

                    await trainerRepository.AddAsync(trainer);
                    await unitOfWork.SaveChangesAsync();

                    var emailForNewUserDto = new EmailForNewUserDto
                    {
                        To = $"{trainer.Name} {trainer.Surname}",
                        EmailTo = trainer.Email
                    };

                    rabbitmqPublisherService.EnqueueModel<EmailForNewUserDto>(emailForNewUserDto, QueueName.NewTrainer);

                    dataResult = new SuccessDataResult<TrainerDto>(trainer.Adapt<TrainerDto>(), $"{stringLocalizer[Message.Student_Trainer_Role_Was_Added_Successfully]}\n{stringLocalizer[Message.Rabbitmq_StartSendingEmailProcess_Was_Successful]}");
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Student_Trainer_Role_Could_Not_Be_Added]} : {exception.Message}");
                    dataResult = new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Student_Trainer_Role_Could_Not_Be_Added]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return dataResult;
        }

        public async Task<IDataResult<TrainerDto>> GetByEmailAsync(string email) =>
        await trainerRepository.GetFirstOrDefaultAsync(trainer => trainer.Email == email) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ByEmail]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetFirstOrDefaultAsync(trainer => trainer.Email == email)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ByEmail]);

        public async Task<IDataResult<TrainerDto>> GetByIdAsync(Guid id) =>
        await trainerRepository.GetByIdAsync(id) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ById]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetByIdAsync(id)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ById]);

        public async Task<IDataResult<TrainerDto>> GetByIdentityIdAsync(Guid identityId) =>
            await trainerRepository.GetByIdentityIdAsync(identityId) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetByIdentityIdAsync(identityId)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ByIdentityId]);
    }
}