namespace EAApplication.UserOperationClaims.DTOs
{
    public class CreateUserOperationClaimDto
    {
        public CreateUserOperationClaimDto()
        {
            
        }
        public CreateUserOperationClaimDto(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
