namespace InveonCourseApp.Backend.Dtos.PaymentDtos
{
    public class PaymentAddDto
    {
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}