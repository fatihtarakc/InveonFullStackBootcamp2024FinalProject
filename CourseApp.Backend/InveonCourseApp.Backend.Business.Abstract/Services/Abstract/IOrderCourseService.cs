namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IOrderCourseService
    {
        Task<IResult> AddAsync(OrderCourseAddDto courseOrderAddDto);
    }
}