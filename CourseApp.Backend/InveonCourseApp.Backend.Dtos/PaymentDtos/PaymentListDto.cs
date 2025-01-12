namespace InveonCourseApp.Backend.Dtos.PaymentDtos
{
    public class PaymentListDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}