namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Course> IncludeGetFirstOrDefaultAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<Course> IncludeGetFirstOrDefaultAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<Course>> IncludeGetAllWhereAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<Course, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<Course>> IncludeGetAllWhereAsync(Expression<Func<Course, bool>> expression, Expression<Func<Course, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Course, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}