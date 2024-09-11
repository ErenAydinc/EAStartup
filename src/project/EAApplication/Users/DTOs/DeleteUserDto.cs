namespace EAApplication.Users.DTOs
{
    public class DeleteUserDto
    {
        public DeleteUserDto()
        {
            
        }

        public DeleteUserDto(string? email, int id)
        {
            Email = email;
            Id = id;
        }
        public int Id { get; set; }
        public string? Email { get; set; }
    }
}
