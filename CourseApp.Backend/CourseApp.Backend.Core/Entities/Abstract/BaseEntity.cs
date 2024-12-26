namespace CourseApp.Backend.Core.Entities.Abstract
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}