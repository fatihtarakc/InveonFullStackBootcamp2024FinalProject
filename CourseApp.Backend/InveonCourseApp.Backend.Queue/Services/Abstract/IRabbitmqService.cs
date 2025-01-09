namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IRabbitmqService
    {
        IConnection CreateConnection();

        IModel CreateModel(IConnection connection);
    }
}