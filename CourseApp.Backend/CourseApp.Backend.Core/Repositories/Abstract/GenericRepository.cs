namespace CourseApp.Backend.Core.Repositories.Abstract
{
    public abstract class GenericRepository
    {
        private readonly DbSet<T> dbEntity;
        private readonly IdentityDbContext<IdentityUser, IdentityRole, string> db;
        protected GenericRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db)
        {
            this.db = db;
        }
    }
}