namespace InveonCourseApp.Backend.BackgroundJobs
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var userRole = httpContext.User.FindFirstValue(ClaimTypes.Role);
            return userRole == Role.Admin.ToString() || userRole == Role.Student.ToString() || userRole == Role.Trainer.ToString();
        }
    }
}