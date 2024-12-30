namespace InveonCourseApp.Backend.Queue.Services.Abstract
{
    public interface IRabbitmqService
    {
        Task<IChannel> CreateChannelAsync();
    }
}