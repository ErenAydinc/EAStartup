namespace Core.EAInfrastructure
{
    public interface IQuery<T>
    {
            IQueryable<T> Query();
    }
}
