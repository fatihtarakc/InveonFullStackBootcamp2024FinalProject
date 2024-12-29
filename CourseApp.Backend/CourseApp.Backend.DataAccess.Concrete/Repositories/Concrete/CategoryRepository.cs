namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }
    }
}