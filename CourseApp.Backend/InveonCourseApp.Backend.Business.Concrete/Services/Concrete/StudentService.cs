namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<StudentService> logger;
        public StudentService(IStudentRepository studentRepository, IStringLocalizer<MessageResources> stringLocalizer, ILogger<StudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<StudentDto>> GetByIdAsync(Guid id) =>
            await studentRepository.GetByIdAsync(id) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ById]) : new SuccessDataResult<StudentDto>((await studentRepository.GetByIdAsync(id)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ById]);

        public async Task<IDataResult<StudentDto>> GetByEmailAsync(string email) =>
            await studentRepository.GetFirstOrDefaultAsync(student => student.Email == email) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ByEmail]) : new SuccessDataResult<StudentDto>((await studentRepository.GetFirstOrDefaultAsync(student => student.Email == email)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ByEmail]);

        public async Task<IDataResult<StudentDto>> GetByIdentityIdAsync(Guid identityId) =>
            await studentRepository.GetByIdentityIdAsync(identityId) is null ? new ErrorDataResult<StudentDto>(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]) : new SuccessDataResult<StudentDto>((await studentRepository.GetByIdentityIdAsync(identityId)).Adapt<StudentDto>(), stringLocalizer[Message.Student_Was_Found_ByIdentityId]);
    }
}