﻿namespace InveonCourseApp.Backend.Dtos.PaymentDtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Relations
        public Guid StudentId { get; set; }
        public Guid OrderId { get; set; }
    }
}