namespace InveonCourseApp.Backend.Core.Options
{
    public class ConnectionOptions
    {
        public const string ConnectionConfiguration = "ConnectionConfiguration";

        public string MssqlServer { get; set; }
        public string Hangfire { get; set; }
        public Rabbitmq Rabbitmq { get; set; }
        public string Redis { get; set; }
    }

    public class  Rabbitmq
    {
        public int Port { get; set; }
        public string Hostname { get; set; }
        public string Virtualhost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}