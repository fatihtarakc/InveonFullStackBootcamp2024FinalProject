namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ICourseOrderService
    {
        Task<IDataResult<CourseOrderDto>> AddAsync(CourseOrderAddDto courseOrderAddDto);
    }
}