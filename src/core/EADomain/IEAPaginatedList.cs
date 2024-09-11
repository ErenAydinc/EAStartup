namespace Core.EADomain
{
    public interface IEAPaginatedList<T>
    {
        public List<T> Items { get;}
        public int PageIndex { get;}
        public int PageSize { get; }
        public int TotalPages { get;}
        public int PageItemsCount { get; }
        public int TotalItemsCount { get; }
        public bool HasPreviousPage { get;}
        public bool HasNextPage { get;}
    }
}
