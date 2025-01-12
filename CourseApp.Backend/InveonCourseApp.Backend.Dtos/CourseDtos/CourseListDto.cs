namespace InveonCourseApp.Backend.Dtos.CourseDtos
{
    public class CourseListDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
    }
}