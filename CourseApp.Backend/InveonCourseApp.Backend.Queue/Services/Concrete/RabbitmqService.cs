namespace InveonCourseApp.Backend.Queue.Services.Concrete
{
    public class RabbitmqService : IRabbitmqService
    {
        private readonly ConnectionOptions connectionOptions;
        public RabbitmqService(IOptions<ConnectionOptions> connectionOptions)
        {
            this.connectionOptions = connectionOptions.Value;
        }

        public IConnection CreateConnection()
        {
            try
            {
                var rabbitmq = connectionOptions.Rabbitmq;
                var factory = new ConnectionFactory { /*Port = rabbitmq.Port, */HostName = rabbitmq.Hostname, VirtualHost = rabbitmq.Virtualhost, UserName = rabbitmq.Username, Password = rabbitmq.Password };
                factory.AutomaticRecoveryEnabled = true;  // Otomatik bağlantıyı etkinleştirmek için.
                factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);  // Her 10 saniye de bir tekrar bağlanmaya çalışır.
                factory.TopologyRecoveryEnabled = false;  // Sunucudan bağlantısı kesildikten sonra kuyruktaki mesaj tüketimini sürdürmez.
                return factory.CreateConnection();
            }
            catch
            {
                Thread.Sleep(5000);
                return CreateConnection();
            }
        }

        public IModel CreateModel(IConnection connection) => connection.CreateModel();
    }
}