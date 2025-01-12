namespace InveonCourseApp.Backend.Dtos.OrderDtos
{
    public class OrderAddDto
    {
        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }

        // Relations
        public Guid StudentId { get; set; }
    }
}