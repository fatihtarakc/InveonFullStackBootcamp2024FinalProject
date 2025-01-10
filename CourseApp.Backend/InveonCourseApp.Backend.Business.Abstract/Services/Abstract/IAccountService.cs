namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IAccountService
    {
        Task<IResult> ActivateAsync(IdentityUserActivateAccountDto identityUserActivateAccountDto);

        Task<IdentityResult> AddToRoleAsync(IdentityUser identityUser, Role role);

        Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression);

        Task<IResult> ConfirmEmailAsync(IdentityUserConfirmEmailDto identityUserConfirmEmailDto);

        Task<IdentityUser> FindByEmailAsync(string email);

        Task<IdentityUser> FindByIdAsync(string id);

        Task<IEnumerable<Role>> GetRolesAsync(IdentityUser identityUser);

        Task<IResult> ResetPasswordAsync(IdentityUserResetPasswordDto identityUserResetPasswordDto);

        Task<IResult> SendVerificationCodeWithEmailAsync(string email, VerificationType verificationType);

        #region SignIn, SignUp and SignOut Methods
        Task<SignInResult> PasswordSignInAsync(IdentityUser identityUser, string password, bool isPersistent = false, bool isLockoutOnFailure = false);

        Task SignOutAsync();

        Task<IdentityResult> SignUpAsync(IdentityUser identityUser, Role role);
        #endregion
    }
}