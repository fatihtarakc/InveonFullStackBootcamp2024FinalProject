﻿namespace InveonCourseApp.Backend.BackgroundJobs.Schedules
{
    public static class FireAndForgetJobs
    {
        public static void SendEmailJob() =>
            Hangfire.BackgroundJob.Enqueue<SendEmailJobManager>(job => job.Execute());
    }
}