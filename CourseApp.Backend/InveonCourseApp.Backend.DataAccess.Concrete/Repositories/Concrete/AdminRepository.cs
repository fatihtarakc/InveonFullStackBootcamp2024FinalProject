namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(InveonCourseAppDbContext db) : base(db) { }
    }
}