using EARepository.Abstractions;

namespace EASecurity.Authorization
{
    public class User(string? firstName, string? lastName, string? email, List<string>? roles, bool? isActive, string? token, string? password) : EAEntity
    {
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName;
        public string? Email { get; set; } = email;
        public List<string>? Roles { get; set; } = roles;
        public bool? IsActive { get; set; } = isActive;
        public string? Token { get; set; } = token;
        public string? Password { get; set; } = password;
    }
}
