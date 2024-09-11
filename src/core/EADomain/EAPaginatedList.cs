namespace Core.EADomain
{
    public class EAPaginatedList<T> : IEAPaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int PageItemsCount { get; }
        public int TotalItemsCount { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public EAPaginatedList(List<T> items, int pageIndex, int pageSize, int totalPages,int pageItemsCount,int totalItemsCount)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
            PageItemsCount = pageItemsCount;
        }
    }
}
