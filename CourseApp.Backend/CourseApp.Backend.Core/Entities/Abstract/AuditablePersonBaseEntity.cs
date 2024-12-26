namespace CourseApp.Backend.Core.Entities.Abstract
{
    public class AuditablePersonBaseEntity : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? VerificationCode { get; set; }
        public string IdentityId { get; init; }
        public AccountStatus AccountStatus { get; set; }
    }
}