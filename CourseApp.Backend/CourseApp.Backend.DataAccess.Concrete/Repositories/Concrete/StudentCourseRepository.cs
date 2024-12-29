namespace CourseApp.Backend.DataAccess.Concrete.Repositories.Concrete
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(IdentityDbContext<IdentityUser, IdentityRole, string> db) : base(db) { }

        public async Task<StudentCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).FirstOrDefaultAsync(expression);

        public async Task<StudentCourse> IncludeGetFirstOrDefaultAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<object, object>> thenInclude, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).FirstOrDefaultAsync(expression);

        public async Task<ICollection<StudentCourse>> IncludeGetAllWhereAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<StudentCourse, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).Where(expression).OrderBy(orderby).ToListAsync();

        public async Task<ICollection<StudentCourse>> IncludeGetAllWhereAsync(Expression<Func<StudentCourse, bool>> expression, Expression<Func<StudentCourse, object>> include, Expression<Func<object, object>> thenInclude, Expression<Func<StudentCourse, object>> orderby, bool tracking = true) =>
            await GetAllByStatusIsNotDeletedByTracking(tracking).Include(include).ThenInclude(thenInclude).Where(expression).OrderBy(orderby).ToListAsync();
    }
}