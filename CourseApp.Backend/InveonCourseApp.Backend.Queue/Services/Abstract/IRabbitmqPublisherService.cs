namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IRabbitmqPublisherService
    {
        IResult EnqueueModel<T>(T queueDataModel, string queueName) where T : class, new();

        IResult EnqueueModels<T>(IEnumerable<T> queueDataModels, string queueName) where T : class, new();
    }
}