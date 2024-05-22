using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACrossCuttingConcerns.Generic
{
    public class EAPaginatedList<T>:IEAPaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public EAPaginatedList(List<T> items, int pageIndex, int totalPages)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
    }
}
