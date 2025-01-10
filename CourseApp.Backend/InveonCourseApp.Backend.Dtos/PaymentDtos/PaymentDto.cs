namespace InveonCourseApp.Backend.Dtos.PaymentDtos
{
    public class PaymentDto
    {
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid StudentId { get; init; }
        public Guid OrderId { get; init; }
    }
}