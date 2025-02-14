﻿namespace InveonCourseApp.Backend.Dtos.OrderDtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Relations
        public Guid StudentId { get; set; }
    }
}