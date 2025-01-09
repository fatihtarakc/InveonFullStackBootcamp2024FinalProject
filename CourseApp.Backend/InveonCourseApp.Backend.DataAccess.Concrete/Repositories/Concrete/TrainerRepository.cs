namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Trainer> GetByIdentityIdAsync(Guid identityId) =>
            await dbEntity.FirstOrDefaultAsync(trainer => trainer.IdentityId == identityId);

        public async Task<Trainer> IncludeGetFirstOrDefaultAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<Trainer> IncludeGetFirstOrDefaultAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<Trainer>> IncludeGetAllWhereAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<Trainer, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<Trainer>> IncludeGetAllWhereAsync(Expression<Func<Trainer, bool>> expression, Expression<Func<Trainer, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Trainer, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}