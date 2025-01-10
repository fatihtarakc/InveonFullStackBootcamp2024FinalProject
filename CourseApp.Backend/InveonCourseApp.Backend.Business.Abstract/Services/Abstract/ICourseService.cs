namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ICourseService
    {
        Task<IDataResult<CourseDto>> AddAsync(CourseAddDto courseAddDto);

        Task<IDataResult<CourseDto>> GetByIdAsync(Guid courseId);

        Task<IDataResult<List<CourseDto>>> GetAllWhereAsync(Expression<Func<Course, bool>> expression);

        Task<IDataResult<List<CourseDto>>> GetAllAsync();
    }
}