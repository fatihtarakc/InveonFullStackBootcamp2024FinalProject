namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Trainer> GetByIdentityIdAsync(Guid identityId) =>
            await dbEntity.FirstOrDefaultAsync(trainer => trainer.IdentityId == identityId);
    }
}