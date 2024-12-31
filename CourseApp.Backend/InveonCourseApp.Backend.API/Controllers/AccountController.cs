namespace InveonCourseApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IStudentService studentService;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        public AccountController(IAccountService accountService, IStudentService studentService, IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.accountService = accountService;
            this.studentService = studentService;
            this.stringLocalizer = stringLocalizer;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(IdentityUserSignInDto identityUserSignInDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var identityUser = await accountService.FindByEmailAsync(identityUserSignInDto.Email);
            if (identityUser is null) return BadRequest(stringLocalizer[Message.Account_SignIn_Failed]);

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await accountService.PasswordSignInAsync(identityUser, identityUserSignInDto.Password, identityUserSignInDto.IsPersistant);
            if (!signInResult.Succeeded)
            {
                if (!identityUser.EmailConfirmed) return Unauthorized("Your email could not have been confirmed !\nA new confirm code was sent.");

                return BadRequest("This email address or password is incorrect !");
            }

            var roles = await accountService.GetRolesAsync(identityUser);
            if (roles.Contains(Role.Admin)) return Ok();
            if (roles.Contains(Role.Trainer)) return Ok();
            if (roles.Contains(Role.Student)) return Ok();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(IdentityUserSignUpDto identityUserSignUpDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var identityUser = await accountService.FindByEmailAsync(identityUserSignUpDto.Email);
            if (identityUser is not null) return BadRequest("This email address cannot be used !");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult EmailConfirm()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EmailConfirm(IdentityUserEmailConfirmDto identityUserEmailConfirmDto)
        {
            return Ok(identityUserEmailConfirmDto.VerificationCode);
        }
    }
}