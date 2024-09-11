namespace EAApplication.OperationClaims.DTOs
{
    public class DeleteOperationClaimDto
    {
        public int Id { get; set; }

        public DeleteOperationClaimDto(int id)
        {
            Id = id;
        }
        public DeleteOperationClaimDto()
        {
        }
    }
}
