﻿namespace InveonCourseApp.Backend.Core.Options
{
    public class EmailOptions
    {
        public const string EmailConfiguraiton = "EmailConfiguration";

        public string From { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}