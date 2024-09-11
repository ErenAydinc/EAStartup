namespace EAApplication.Users.DTOs
{
    public class UserDto
    {
        public UserDto()
        {

        }
        public UserDto(string? firstName, string? lastName, string? email, bool? isActive, string? token, string? password, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsActive = isActive;
            Token = token;
            Password = password;
            Id = id;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
