namespace InveonCourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(InveonCourseAppDbContext db) : base(db) { }

        public async Task<Student> IncludeGetFirstOrDefaultAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<Student> IncludeGetFirstOrDefaultAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<Student>> IncludeGetAllWhereAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<Student, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<Student>> IncludeGetAllWhereAsync(Expression<Func<Student, bool>> expression, Expression<Func<Student, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<Student, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}