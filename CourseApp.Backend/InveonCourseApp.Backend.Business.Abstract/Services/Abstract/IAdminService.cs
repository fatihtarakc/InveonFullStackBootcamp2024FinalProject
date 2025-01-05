namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IAdminService
    {
        Task<IDataResult<AdminDto>> GetByIdAsync(Guid id);

        Task<IDataResult<AdminDto>> GetByEmailAsync(string email);

        Task<IDataResult<AdminDto>> GetByIdentityIdAsync(Guid identityId);
    }
}