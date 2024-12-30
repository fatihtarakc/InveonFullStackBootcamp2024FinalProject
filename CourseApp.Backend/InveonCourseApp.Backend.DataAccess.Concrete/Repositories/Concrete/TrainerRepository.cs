namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(InveonCourseAppDbContext db) : base(db) { }
    }
}