namespace EAApplication.OperationClaims.DTOs
{
    public class CreateOperationClaimDto
    {
        public CreateOperationClaimDto(string name)
        {
            Name = name;
        }
        public CreateOperationClaimDto()
        {
                
        }
        public string Name { get; set; }
    }
}
