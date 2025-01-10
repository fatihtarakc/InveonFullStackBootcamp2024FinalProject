namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId);

        Task<IDataResult<List<CategoryDto>>> GetAllAsync();
    }
}