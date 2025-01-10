namespace InveonCourseApp.Backend.Dtos.CourseDtos
{
    public class CourseAddDto
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid CategoryId { get; set; }
        public Guid TrainerId { get; set; }
    }
}