﻿namespace InveonCourseApp.Backend.Dtos.IdentityUserDtos
{
    public class IdentityUserSignUpDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
    }
}