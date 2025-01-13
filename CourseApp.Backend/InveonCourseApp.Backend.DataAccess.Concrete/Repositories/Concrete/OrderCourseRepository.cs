namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class OrderCourseRepository : GenericRepository<OrderCourse>, IOrderCourseRepository
    {
        public OrderCourseRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<OrderCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<OrderCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<OrderCourse>> IncludeGetAllWhereAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<OrderCourse, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<OrderCourse>> IncludeGetAllWhereAsync(Expression<Func<OrderCourse, bool>> expression, Expression<Func<OrderCourse, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<OrderCourse, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}