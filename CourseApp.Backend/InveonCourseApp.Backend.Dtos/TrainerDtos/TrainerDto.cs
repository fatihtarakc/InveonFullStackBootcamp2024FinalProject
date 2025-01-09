namespace InveonCourseApp.Backend.Dtos.TrainerDtos
{
    public class TrainerDto : AuditablePersonBaseEntityDto
    {
        public DateTime Birthdate { get; set; }
    }
}