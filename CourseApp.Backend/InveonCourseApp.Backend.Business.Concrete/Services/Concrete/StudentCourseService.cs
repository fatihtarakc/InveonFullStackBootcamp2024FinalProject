namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly ICacheService<StudentCourse> cacheService;
        private readonly IStudentCourseRepository studentCourseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<StudentCourseService> logger;
        public StudentCourseService(ICacheService<StudentCourse> cacheService, IStudentCourseRepository studentCourseRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<StudentCourseService> logger)
        {
            this.cacheService = cacheService;
            this.studentCourseRepository = studentCourseRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }
    }
}