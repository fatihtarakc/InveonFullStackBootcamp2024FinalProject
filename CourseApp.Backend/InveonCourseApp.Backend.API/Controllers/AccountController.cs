namespace InveonCourseApp.Backend.API.Controllers
{
    public class AccountController : CustomControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IAdminService adminService;
        private readonly IStudentService studentService;
        private readonly ITokenService tokenService;
        private readonly ITrainerService trainerService;
        public AccountController(IAccountService accountService, IAdminService adminService, IStudentService studentService, ITokenService tokenService, ITrainerService trainerService, IStringLocalizer<MessageResources> stringLocalizer) : base(stringLocalizer)
        {
            this.accountService = accountService;
            this.adminService = adminService;
            this.studentService = studentService;
            this.tokenService = tokenService;
            this.trainerService = trainerService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] IdentityUserSignInDto identityUserSignInDto)
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

            AuditablePersonBaseEntityDto auditablePersonBaseEntityDto = null;

            var roles = await accountService.GetRolesAsync(identityUser);
            if (roles.Contains(Role.Admin))
            {
                var adminDtoDataResult = await adminService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                if (!adminDtoDataResult.IsSuccess) return BadRequest(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);

                var adminDto = adminDtoDataResult.Data;
                if (adminDto is null) return BadRequest(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);

                auditablePersonBaseEntityDto = new AdminDto { IdentityId = Guid.Parse(identityUser.Id) };
                auditablePersonBaseEntityDto = adminDto.Adapt<AdminDto>();
            }
            else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
            {
                var trainerDtoDataResult = await trainerService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                if (!trainerDtoDataResult.IsSuccess) return BadRequest(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);

                var trainerDto = trainerDtoDataResult.Data;
                if (trainerDto is null) return BadRequest(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);

                auditablePersonBaseEntityDto = new TrainerDto { IdentityId = Guid.Parse(identityUser.Id) };
                auditablePersonBaseEntityDto = trainerDto.Adapt<TrainerDto>();
            }
            else if (roles.Contains(Role.Student))
            {
                var studentDtoDataResult = await studentService.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                if (!studentDtoDataResult.IsSuccess) return BadRequest(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);

                var studentDto = studentDtoDataResult.Data;
                if (studentDto is null) return BadRequest(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);

                auditablePersonBaseEntityDto = new StudentDto { IdentityId = Guid.Parse(identityUser.Id) };
                auditablePersonBaseEntityDto = studentDto.Adapt<StudentDto>();
            }
            else return Unauthorized(stringLocalizer[Message.Account_Role_Was_Not_Found_For_IdentityUser]);

            if (auditablePersonBaseEntityDto.AccountStatus is AccountStatus.Passive) return BadRequest(stringLocalizer[Message.Account_Has_Not_Activated]);

            var tokenDtoDataResult = await tokenService.CreateAccessTokenAsync(identityUser, (AuditablePersonBaseEntityDto)auditablePersonBaseEntityDto);
            if (!tokenDtoDataResult.IsSuccess) return BadRequest(stringLocalizer[Message.Token_Could_Not_Generated]);

            string rolesArray = "";
            foreach (var role in roles)
            {
                rolesArray += $"{Enum.GetName(typeof(Role), role)}, ";
            }

            if (!string.IsNullOrWhiteSpace(rolesArray)) rolesArray = rolesArray.Substring(0, rolesArray.Length - 2);
            return Ok($"Welcome to InveonCourseApp !\nRole : {rolesArray}\n{tokenDtoDataResult.Message}\nAccess Token : {tokenDtoDataResult.Data!.AccessToken}\nExpiration Date : {tokenDtoDataResult.Data.Expiration}");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] StudentAddDto studentAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var studentDtoDataResult = await studentService.AddAsync(studentAddDto);
            if (!studentDtoDataResult.IsSuccess) return BadRequest(studentDtoDataResult.Message);

            return Ok($"{studentDtoDataResult.Message}\nWelcome to Inveon Course App {studentDtoDataResult.Data!.Name} {studentDtoDataResult.Data!.Surname} !\n{stringLocalizer[Message.Account_Email_Has_Not_Confirmed]}\n{stringLocalizer[Message.Account_Has_Not_Activated]}");
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(string email)
        {
            if (!(await accountService.AnyAsync(identityUser => identityUser.Email == email))) return BadRequest(stringLocalizer[Message.Account_Email_Is_Invalid]);

            var result = await accountService.SendVerificationCodeWithEmailAsync(email, VerificationType.ActivateAccount);
            if (!result.IsSuccess) return BadRequest(stringLocalizer[Message.Email_SendingProcess_Was_Failed]);

            return Ok($"{result.Message}");
        }

        [HttpPost]
        public async Task<IActionResult> Activate([FromBody] IdentityUserActivateAccountDto identityUserActivateAccountDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await accountService.ActivateAsync(identityUserActivateAccountDto);
            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email)
        {
            if (!(await accountService.AnyAsync(identityUser => identityUser.Email == email))) return BadRequest(stringLocalizer[Message.Account_Email_Is_Invalid]);

            var result = await accountService.SendVerificationCodeWithEmailAsync(email, VerificationType.ConfirmEmail);
            if (!result.IsSuccess) return BadRequest(stringLocalizer[Message.Email_SendingProcess_Was_Failed]);

            return Ok($"{result.Message}");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail([FromBody] IdentityUserConfirmEmailDto identityUserEmailConfirmDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await accountService.ConfirmEmailAsync(identityUserEmailConfirmDto);
            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (!(await accountService.AnyAsync(identityUser => identityUser.Email == email))) return BadRequest(stringLocalizer[Message.Account_Email_Is_Invalid]);

            var result = await accountService.SendVerificationCodeWithEmailAsync(email, VerificationType.ResetPassword);
            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] IdentityUserResetPasswordDto identityUserForgotPasswordDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await accountService.ResetPasswordAsync(identityUserForgotPasswordDto);
            if (!result.IsSuccess) return BadRequest($"{result.Message}");

            await accountService.SignOutAsync();
            return Ok($"{result.Message} : Your account was signed out !");
        }
    }
}