namespace Core.EADomain.Domains
{
    public class UserOperationClaim:EAEntity
    {
        public UserOperationClaim()
        {
            
        }
        public UserOperationClaim(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
