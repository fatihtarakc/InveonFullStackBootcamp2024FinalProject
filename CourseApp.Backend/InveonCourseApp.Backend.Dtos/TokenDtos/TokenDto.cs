namespace InveonCourseApp.Backend.Dtos.TokenDtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}