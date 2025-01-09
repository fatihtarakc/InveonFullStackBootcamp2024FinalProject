namespace InveonCourseApp.Backend.Queue.Services.Concrete
{
    public class RabbitmqPublisherService : IRabbitmqPublisherService
    {
        private readonly IRabbitmqService rabbitmqService;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<RabbitmqPublisherService> logger;
        public RabbitmqPublisherService(IRabbitmqService rabbitmqService, IStringLocalizer<MessageResources> stringLocalizer, ILogger<RabbitmqPublisherService> logger)
        {
            this.rabbitmqService = rabbitmqService;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public IResult EnqueueModel<T>(T queueDataModel, string queueName) where T : class, new()
        {
            try
            {
                using (var connection = rabbitmqService.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                        durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(queueDataModel));
                    channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
                }

                return new SuccessResult(stringLocalizer[Message.Rabbitmq_EnqueueModelProcess_Was_Successful]);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
                return new ErrorResult($"{stringLocalizer[Message.Rabbitmq_EnqueueModelProcess_Was_Successful]} : {exception.Message}");
            }
        }

        public IResult EnqueueModels<T>(IEnumerable<T> queueDataModels, string queueName) where T : class, new()
        {
            try
            {
                using (var connection = rabbitmqService.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    foreach (var queueDataModel in queueDataModels)
                    {
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(queueDataModel));
                        channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
                    }
                }

                return new SuccessResult(stringLocalizer[Message.Rabbitmq_EnqueueModelsProcess_Were_Successful]);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
                return new ErrorResult($"{stringLocalizer[Message.Rabbitmq_EnqueueModelsProcess_Were_Failed]} : {exception.Message}");
            }
        }
    }
}