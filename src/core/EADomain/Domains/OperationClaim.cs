namespace Core.EADomain.Domains
{
    public class OperationClaim:EAEntity
    {
        public OperationClaim()
        {

        }

        public OperationClaim(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
