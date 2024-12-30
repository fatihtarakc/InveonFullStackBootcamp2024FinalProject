namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Payment> IncludeGetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<Payment> IncludeGetFirstOrDefaultAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<Payment>> IncludeGetAllWhereAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<Payment, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<Payment>> IncludeGetAllWhereAsync(Expression<Func<Payment, bool>> expression, Expression<Func<Payment, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Payment, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}