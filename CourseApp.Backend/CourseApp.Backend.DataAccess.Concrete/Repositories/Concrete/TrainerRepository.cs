namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }
    }
}