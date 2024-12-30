namespace InveonCourseApp.Backend.Dtos.EmailDtos
{
    public record EmailDto(string To, string EmailTo, string Title, string Subject, string Content);
}