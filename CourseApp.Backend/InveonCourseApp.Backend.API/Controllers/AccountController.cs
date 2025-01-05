namespace InveonCourseApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IAdminService adminService;
        private readonly IStudentService studentService;
        private readonly ITrainerService trainerService;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        public AccountController(IAccountService accountService, IAdminService adminService, IStudentService studentService, ITrainerService trainerService, IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.accountService = accountService;
            this.adminService = adminService;
            this.studentService = studentService;
            this.trainerService = trainerService;
            this.stringLocalizer = stringLocalizer;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(IdentityUserSignInDto identityUserSignInDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var identityUser = await accountService.FindByEmailAsync(identityUserSignInDto.Email);
            if (identityUser is null) return BadRequest(stringLocalizer[Message.Account_SignIn_Failed]);

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await accountService.PasswordSignInAsync(identityUser, identityUserSignInDto.Password, identityUserSignInDto.IsPersistant);
            if (!signInResult.Succeeded)
            {
                if (!identityUser.EmailConfirmed) return BadRequest(stringLocalizer[Message.Account_Email_Has_Not_Confirmed]);

                return BadRequest(stringLocalizer[Message.Account_SignIn_Failed]);
            }

            var roles = await accountService.GetRolesAsync(identityUser);

            if (roles.Contains(Role.Admin))
            {
                var adminDto = (await adminService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id))).Data;
                if (adminDto is null) return BadRequest(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);

                if (adminDto.AccountStatus is AccountStatus.Passive) return BadRequest(stringLocalizer[Message.Account_Has_Not_Activated]);

                return Ok("access token - admin area name surname welcome");
            }
            else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
            {
                var trainerDto = (await trainerService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id))).Data;
                if (trainerDto is null) return BadRequest(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);

                if (trainerDto.AccountStatus is AccountStatus.Passive) return BadRequest(stringLocalizer[Message.Account_Has_Not_Activated]);

                return Ok("access token - student area name surname welcome");
            }
            else if (roles.Contains(Role.Student))
            {
                var studentDto = (await studentService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id))).Data;
                if (studentDto is null) return BadRequest(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);

                if (studentDto.AccountStatus is AccountStatus.Passive) return BadRequest(stringLocalizer[Message.Account_Has_Not_Activated]);

                return Ok("access token - student area name surname welcome");
            }
            return Unauthorized();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(IdentityUserSignUpDto identityUserSignUpDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var identityUser = await accountService.FindByEmailAsync(identityUserSignUpDto.Email);
            if (identityUser is not null) return BadRequest("This email address cannot be used !");

            return Ok("kayıt başarılı !");
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult Activate(string email)
        {
            return Ok("hesabınızı active etmek için email doğrulama kodu gönderildi - doğrulama kodu kaydedildi !");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(IdentityUserActivateAccountDto identityUserActivateAccountDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(identityUserActivateAccountDto.VerificationCode);
        }

        [HttpGet]
        public IActionResult ConfirmEmail(string email)
        {
            return Ok("email doğrulama kodu gönderildi - doğrulama kodu kaydedildi !");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEmail(IdentityUserConfirmEmailDto identityUserEmailConfirmDto)
        {
            return Ok(identityUserEmailConfirmDto.VerificationCode);
        }

        [HttpGet]
        public IActionResult ChangePassword(string email)
        {
            return Ok("şifre değiştirme işlemi için email doğrulama kodu gönderildi - doğrulama kodu kaydedildi !");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ChangePassword(IdentityUserChangePasswordDto identityUserChangePasswordDto)
        {
            return Ok("");
        }

        [HttpGet]
        public IActionResult ForgotPassword(string email)
        {
            return Ok("şifre yenileme işlemi için email doğrulama kodu gönderildi - doğrulama kodu kaydedildi !");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(IdentityUserForgotPasswordDto identityUserForgotPasswordDto)
        {
            return Ok("");
        }
    }
}