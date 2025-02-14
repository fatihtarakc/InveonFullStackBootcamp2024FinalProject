﻿namespace InveonCourseApp.Backend.Dtos.OrderDtos
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public int TotalCourseAmount { get; set; }
        public decimal TotalCoursePrice { get; set; }
        public Currency Currency { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }
    }
}