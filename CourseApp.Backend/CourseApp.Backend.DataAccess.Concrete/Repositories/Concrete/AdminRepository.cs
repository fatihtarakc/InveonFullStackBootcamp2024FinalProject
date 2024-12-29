namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }
    }
}