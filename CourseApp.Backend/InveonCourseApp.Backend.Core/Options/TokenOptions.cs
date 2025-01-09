namespace InveonCourseApp.Backend.Core.Options
{
    public class TokenOptions
    {
        public const string TokenConfiguration = "TokenConfiguration";

        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string IssuerSigningSymmetricSecurityKey { get; set; }
        public int Expiration { get; set; }
    }
}