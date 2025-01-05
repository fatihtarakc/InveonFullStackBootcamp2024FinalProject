namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Admin> GetByIdentityIdAsync(Guid identityId) =>
            await dbEntity.FirstOrDefaultAsync(admin => admin.IdentityId == identityId);
    }
}