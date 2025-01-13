namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto);

        Task<IResult> DeleteAsync(Guid categoryId);

        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);

        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId);

        Task<IDataResult<CategoryDto>> GetByNameAsync(string categoryName);

        Task<IDataResult<List<CategoryListDto>>> GetAllAsync();
    }
}