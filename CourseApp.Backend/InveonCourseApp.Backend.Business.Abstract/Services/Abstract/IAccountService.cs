namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IAccountService
    {
        Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression);

        Task<IdentityUser> FindByEmailAsync(string email);

        Task<IdentityUser> FindByIdAsync(string id);

        Task<IEnumerable<Role>> GetRolesAsync(IdentityUser identityUser);

        Task<SignInResult> PasswordSignInAsync(IdentityUser identityUser, string password, bool isPersistent = false, bool isLockoutOnFailure = false);

        Task SignOutAsync();

        Task<IdentityResult> SignUpAsync(IdentityUser identityUser, Role role);
    }
}