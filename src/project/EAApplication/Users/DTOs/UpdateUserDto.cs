﻿namespace EAApplication.Users.DTOs
{
    public class UpdateUserDto
    {
        public UpdateUserDto()
        {
            
        }
        public UpdateUserDto(int id,string? firstName, string? lastName, string? email, string? password, string? ısActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsActive = ısActive;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IsActive { get; set; }
    }
}
