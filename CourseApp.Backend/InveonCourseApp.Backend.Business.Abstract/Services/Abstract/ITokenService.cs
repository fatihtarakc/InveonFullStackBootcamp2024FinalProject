namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ITokenService
    {
        Task<IDataResult<TokenDto>> CreateAccessTokenAsync(IdentityUser identityUser, AuditablePersonBaseEntityDto auditablePersonBaseEntityDto);
    }
}