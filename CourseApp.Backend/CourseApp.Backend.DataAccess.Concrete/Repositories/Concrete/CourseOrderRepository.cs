namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class CourseOrderRepository : GenericRepository<CourseOrder>, ICourseOrderRepository
    {
        public CourseOrderRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }

        public async Task<CourseOrder> IncludeGetFirstOrDefaultAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<CourseOrder> IncludeGetFirstOrDefaultAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<CourseOrder>> IncludeGetAllWhereAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<CourseOrder, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<CourseOrder>> IncludeGetAllWhereAsync(Expression<Func<CourseOrder, bool>> expression, Expression<Func<CourseOrder, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<CourseOrder, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}