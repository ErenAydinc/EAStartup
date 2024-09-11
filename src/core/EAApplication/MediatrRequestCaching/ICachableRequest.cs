namespace Core.EAInfrastructure.Pipelines.MediatrRequestCaching
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
        TimeSpan CacheDuration { get; }
    }
}
