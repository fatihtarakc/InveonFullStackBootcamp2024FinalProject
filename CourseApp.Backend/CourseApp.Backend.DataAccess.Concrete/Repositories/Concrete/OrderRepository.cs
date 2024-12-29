namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }

        public async Task<Order> IncludeGetFirstOrDefaultAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<Order> IncludeGetFirstOrDefaultAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<Order>> IncludeGetAllWhereAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<Order, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<Order>> IncludeGetAllWhereAsync(Expression<Func<Order, bool>> expression, Expression<Func<Order, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Order, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}