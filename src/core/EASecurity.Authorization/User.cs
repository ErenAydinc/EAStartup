using EARepository.Abstractions;

namespace EASecurity.Authorization
{
    public class User : EAEntity
    {
        public User()
        {
            
        }
        public User(string? firstName, string? lastName, string? email, bool? isActive, string? token, string? password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsActive = isActive;
            Token = token;
            Password = password;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
