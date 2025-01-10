namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IRabbitmqPublisherService rabbitmqPublisherService;
        private readonly IAdminRepository adminRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITrainerRepository trainerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<AccountService> logger;
        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IRabbitmqPublisherService rabbitmqPublisherService, IAdminRepository adminRepository, IStudentRepository studentRepository, ITrainerRepository trainerRepository, IUnitOfWork unitOfWork, IStringLocalizer<MessageResources> stringLocalizer, ILogger<AccountService> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.rabbitmqPublisherService = rabbitmqPublisherService;
            this.adminRepository = adminRepository;
            this.studentRepository = studentRepository;
            this.trainerRepository = trainerRepository;
            this.unitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IResult> ActivateAsync(IdentityUserActivateAccountDto identityUserActivateAccountDto)
        {
            var identityUser = await FindByEmailAsync(identityUserActivateAccountDto.Email);
            if (identityUser is null) return new ErrorResult(stringLocalizer[Message.Account_Email_Is_Invalid]);

            if (!identityUser.EmailConfirmed) return new ErrorResult(stringLocalizer[Message.Account_Email_Has_Not_Confirmed]);

            IResult result = new ErrorResult();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var roles = await GetRolesAsync(identityUser);
                    if (roles.Contains(Role.Admin))
                    {
                        var admin = await adminRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (admin is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (admin.AccountStatus is AccountStatus.Active)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Already_Been_Activated]);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(admin.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (admin!.VerificationCode != identityUserActivateAccountDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        admin.VerificationCode = null;
                        admin.AccountStatus = AccountStatus.Active;
                        await adminRepository.UpdateAsync(admin);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
                    {
                        var trainer = await trainerRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (trainer is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (trainer.AccountStatus is AccountStatus.Active)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Already_Been_Activated]);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(trainer.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (trainer!.VerificationCode != identityUserActivateAccountDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        trainer.VerificationCode = null;
                        trainer.AccountStatus = AccountStatus.Active;
                        await trainerRepository.UpdateAsync(trainer);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Student))
                    {
                        var student = await studentRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (student is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (student.AccountStatus is AccountStatus.Active)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Already_Been_Activated]);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(student.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (student!.VerificationCode != identityUserActivateAccountDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        student.VerificationCode = null;
                        student.AccountStatus = AccountStatus.Active;
                        await studentRepository.UpdateAsync(student);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else result = new ErrorResult($"{stringLocalizer[Message.Account_ActivateAccount_Failed]}\n{stringLocalizer[Message.Account_Role_Was_Not_Found_For_IdentityUser]}");

                    result = new SuccessResult(stringLocalizer[Message.Account_ActivateAccount_Successful]);
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Account_ActivateAccount_Failed]} : {exception.Message}");
                    result = new ErrorResult(stringLocalizer[Message.Account_ActivateAccount_Failed]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return result;
        }

        public async Task<IdentityResult> AddToRoleAsync(IdentityUser identityUser, Role role) =>
            await userManager.AddToRoleAsync(identityUser, role.ToString());

        public async Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression) =>
            await userManager.Users.AnyAsync(expression);

        public async Task<IResult> ConfirmEmailAsync(IdentityUserConfirmEmailDto identityUserConfirmEmailDto)
        {
            var identityUser = await FindByEmailAsync(identityUserConfirmEmailDto.Email);
            if (identityUser is null) return new ErrorResult(stringLocalizer[Message.Account_Email_Is_Invalid]);
            if (identityUser.EmailConfirmed) return new ErrorResult(stringLocalizer[Message.Account_Email_Has_Already_Been_Confirmed]);

            IResult result = new ErrorResult();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var roles = await GetRolesAsync(identityUser);
                    if (roles.Contains(Role.Admin))
                    {
                        var admin = await adminRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (admin is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(admin.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (admin!.VerificationCode != identityUserConfirmEmailDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.EmailConfirmed = true;
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ConfirmEmail_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        admin.VerificationCode = null;
                        await adminRepository.UpdateAsync(admin);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
                    {
                        var trainer = await trainerRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (trainer is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(trainer.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (trainer!.VerificationCode != identityUserConfirmEmailDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.EmailConfirmed = true;
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ConfirmEmail_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        trainer.VerificationCode = null;
                        await trainerRepository.UpdateAsync(trainer);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Student))
                    {
                        var student = await studentRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (student is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(student.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (student!.VerificationCode != identityUserConfirmEmailDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.EmailConfirmed = true;
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ConfirmEmail_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        student.VerificationCode = null;
                        await studentRepository.UpdateAsync(student);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else result = new ErrorResult($"{stringLocalizer[Message.Account_ConfirmEmail_Failed]}\n{stringLocalizer[Message.Account_Role_Was_Not_Found_For_IdentityUser]}");

                    result = new SuccessResult(stringLocalizer[Message.Account_ConfirmEmail_Successful]);
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Account_ConfirmEmail_Failed]} : {exception.Message}");
                    result = new ErrorResult(stringLocalizer[Message.Account_ConfirmEmail_Failed]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return result;
        }

        public async Task<IdentityUser> FindByEmailAsync(string email) =>
            await userManager.FindByEmailAsync(email);

        public async Task<IdentityUser> FindByIdAsync(string id) =>
            await userManager.FindByIdAsync(id);

        public async Task<IEnumerable<Role>> GetRolesAsync(IdentityUser identityUser) =>
            (await userManager.GetRolesAsync(identityUser)).Select(role => Enum.Parse<Role>(role));

        public async Task<IResult> ResetPasswordAsync(IdentityUserResetPasswordDto identityUserResetPasswordDto)
        {
            var identityUser = await FindByEmailAsync(identityUserResetPasswordDto.Email);
            if (identityUser is null) return new ErrorResult(stringLocalizer[Message.Account_Email_Is_Invalid]);

            if (!identityUser.EmailConfirmed) return new ErrorResult(stringLocalizer[Message.Account_Email_Has_Not_Confirmed]);

            IResult result = new ErrorResult();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var roles = await GetRolesAsync(identityUser);
                    if (roles.Contains(Role.Admin))
                    {
                        var admin = await adminRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (admin is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (admin!.AccountStatus is AccountStatus.Passive)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Not_Activated]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(admin.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (admin.VerificationCode != identityUserResetPasswordDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, identityUserResetPasswordDto.Password);
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ResetPassword_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        admin.VerificationCode = null;
                        admin.AccountStatus = AccountStatus.Passive;
                        await adminRepository.UpdateAsync(admin);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
                    {
                        var trainer = await trainerRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (trainer is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (trainer!.AccountStatus is AccountStatus.Passive)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Not_Activated]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(trainer.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (trainer!.VerificationCode != identityUserResetPasswordDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, identityUserResetPasswordDto.Password);
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ResetPassword_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        trainer.VerificationCode = null;
                        trainer.AccountStatus = AccountStatus.Passive;
                        await trainerRepository.UpdateAsync(trainer);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else if (roles.Contains(Role.Student))
                    {
                        var student = await studentRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (student is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        if (student!.AccountStatus is AccountStatus.Passive)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Has_Not_Activated]);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(student.VerificationCode))
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_Please_Take_New_VerificationCode]);
                            return;
                        }
                        if (student.VerificationCode != identityUserResetPasswordDto.VerificationCode)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_VerificationCode_Is_Invalid]);
                            return;
                        }

                        identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, identityUserResetPasswordDto.Password);
                        var identityResult = await userManager.UpdateAsync(identityUser);
                        if (!identityResult.Succeeded)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Account_ResetPassword_Failed]);
                            transactionScope.Rollback();
                            return;
                        }

                        student.VerificationCode = null;
                        student.AccountStatus = AccountStatus.Passive;
                        await studentRepository.UpdateAsync(student);
                        await unitOfWork.SaveChangesAsync();
                    }
                    else result = new ErrorResult(stringLocalizer[Message.Account_Role_Was_Not_Found_For_IdentityUser]);

                    result = new SuccessResult($"{stringLocalizer[Message.Account_ResetPassword_Successful]}\n{stringLocalizer[Message.Please_Activate_Your_Account_Again]}");
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Account_ResetPassword_Failed]} : {exception.Message}");
                    result = new ErrorResult(stringLocalizer[Message.Account_ResetPassword_Failed]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return result;
        }

        public async Task<IResult> SendVerificationCodeWithEmailAsync(string email, VerificationType verificationType)
        {
            var identityUser = await FindByEmailAsync(email);
            if (identityUser is null) return new ErrorResult(stringLocalizer[Message.Account_Email_Is_Invalid]);

            IResult result = new ErrorResult();
            var strategy = await unitOfWork.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using var transactionScope = await unitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var roles = await GetRolesAsync(identityUser);
                    var verificationCode = HelperVerification.CodeGenerator();
                    AuditablePersonBaseEntityDto auditablePersonBaseEntityDto = null;
                    if (roles.Contains(Role.Admin))
                    {
                        var admin = await adminRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (admin is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        admin!.VerificationCode = verificationCode;
                        await adminRepository.UpdateAsync(admin);
                        await unitOfWork.SaveChangesAsync();
                        auditablePersonBaseEntityDto = admin.Adapt<AdminDto>();
                    }
                    else if (roles.Contains(Role.Trainer) && roles.Contains(Role.Student))
                    {
                        var trainer = await trainerRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (trainer is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        trainer!.VerificationCode = verificationCode;
                        await trainerRepository.UpdateAsync(trainer);
                        await unitOfWork.SaveChangesAsync();
                        auditablePersonBaseEntityDto = trainer.Adapt<TrainerDto>();
                    }
                    else if (roles.Contains(Role.Student))
                    {
                        var student = await studentRepository.GetByIdentityIdAsync(Guid.Parse(identityUser.Id));
                        if (student is null)
                        {
                            result = new ErrorResult(stringLocalizer[Message.Student_Was_Not_Found_ByIdentityId]);
                            return;
                        }

                        student!.VerificationCode = verificationCode;
                        await studentRepository.UpdateAsync(student);
                        await unitOfWork.SaveChangesAsync();
                        auditablePersonBaseEntityDto = student.Adapt<StudentDto>();
                    }
                    else
                    {
                        result = new ErrorResult(stringLocalizer[Message.Account_Role_Was_Not_Found_For_IdentityUser]);
                        return;
                    }

                    var emailBaseForVerificationDto = new EmailForVerificationDto
                    {
                        To = $"{auditablePersonBaseEntityDto.Name} {auditablePersonBaseEntityDto.Surname}",
                        EmailTo = auditablePersonBaseEntityDto.Email,
                        VerificationCode = verificationCode
                    };
                    if (verificationType is VerificationType.ActivateAccount) rabbitmqPublisherService.EnqueueModel<EmailForVerificationDto>(emailBaseForVerificationDto, QueueName.ActivateAccount);
                    else if (verificationType is VerificationType.ConfirmEmail) rabbitmqPublisherService.EnqueueModel<EmailForVerificationDto>(emailBaseForVerificationDto, QueueName.ConfirmEmail);
                    else if (verificationType is VerificationType.ResetPassword) rabbitmqPublisherService.EnqueueModel<EmailForVerificationDto>(emailBaseForVerificationDto, QueueName.ResetPassword);
                    else result = new ErrorResult(stringLocalizer[Message.Email_SendingProcess_Was_Failed]);

                    result = new SuccessResult($"{stringLocalizer[Message.Email_SendingProcess_Was_Successful]} to {auditablePersonBaseEntityDto.Email}\n{stringLocalizer[Message.Rabbitmq_StartSendingEmailProcess_Was_Successful]}");
                    transactionScope.Commit();
                }
                catch (Exception exception)
                {
                    logger.LogError($"{stringLocalizer[Message.Email_SendingProcess_Was_Failed]} : {exception.Message}");
                    result = new ErrorResult(stringLocalizer[Message.Email_SendingProcess_Was_Failed]);
                    transactionScope.Rollback();
                }
                finally
                {
                    await transactionScope.DisposeAsync();
                }
            });

            return result;
        }

        #region SignIn, SignUp and SignOut Methods
        public async Task<SignInResult> PasswordSignInAsync(IdentityUser identityUser, string password, bool isPersistent = false, bool isLockoutOnFailure = false) =>
            await signInManager.PasswordSignInAsync(identityUser, password, isPersistent, isLockoutOnFailure);

        public async Task SignOutAsync() =>
            await signInManager.SignOutAsync();

        public async Task<IdentityResult> SignUpAsync(IdentityUser identityUser, Role role)
        {
            var identityResult = await userManager.CreateAsync(identityUser);
            if (!identityResult.Succeeded) return identityResult;

            return await userManager.AddToRoleAsync(identityUser, role.ToString());
        }
        #endregion
    }
}