namespace EAApplication.OperationClaims.DTOs
{
    public class UpdateOperationClaimDto
    {
        public UpdateOperationClaimDto(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public UpdateOperationClaimDto()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
