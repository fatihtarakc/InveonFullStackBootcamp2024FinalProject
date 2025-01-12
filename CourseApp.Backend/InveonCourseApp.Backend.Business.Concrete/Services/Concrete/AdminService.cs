namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;

        public AdminService(IAdminRepository adminRepository, IStringLocalizer<MessageResources> stringLocalizer)
        {
            this.adminRepository = adminRepository;
            this.stringLocalizer = stringLocalizer;
        }

        public async Task<IDataResult<AdminDto>> GetByEmailAsync(string email) =>
            await adminRepository.GetFirstOrDefaultAsync(admin => admin.Email == email) is null ? new ErrorDataResult<AdminDto>(stringLocalizer[Message.Admin_Was_Not_Found_ByEmail]) : new SuccessDataResult<AdminDto>((await adminRepository.GetFirstOrDefaultAsync(admin => admin.Email == email)).Adapt<AdminDto>(), stringLocalizer[Message.Admin_Was_Found_ByEmail]);

        public async Task<IDataResult<AdminDto>> GetByIdAsync(Guid id) =>
            await adminRepository.GetByIdAsync(id) is null ? new ErrorDataResult<AdminDto>(stringLocalizer[Message.Admin_Was_Not_Found_ById]) : new SuccessDataResult<AdminDto>((await adminRepository.GetByIdAsync(id)).Adapt<AdminDto>(), stringLocalizer[Message.Admin_Was_Found_ById]);

        public async Task<IDataResult<AdminDto>> GetByIdentityIdAsync(Guid identityId) =>
            await adminRepository.GetByIdentityIdAsync(identityId) is null ? new ErrorDataResult<AdminDto>(stringLocalizer[Message.Admin_Was_Not_Found_ByIdentityId]) : new SuccessDataResult<AdminDto>((await adminRepository.GetByIdentityIdAsync(identityId)).Adapt<AdminDto>(), stringLocalizer[Message.Admin_Was_Found_ByIdentityId]);
    }
}