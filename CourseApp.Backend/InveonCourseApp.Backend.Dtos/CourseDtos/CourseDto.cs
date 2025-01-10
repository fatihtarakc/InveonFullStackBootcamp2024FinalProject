namespace InveonCourseApp.Backend.Dtos.CourseDtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DateTime CreatedDate { get; set; }

        // Relations
        public Guid CategoryId { get; set; }
        public Guid TrainerId { get; set; }
    }
}