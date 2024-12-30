namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InveonCourseAppDbContext db) : base(db) { }
    }
}