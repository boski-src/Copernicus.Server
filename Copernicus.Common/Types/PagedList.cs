using System.Collections.Generic;
using System.Linq;

namespace Copernicus.Common.Types
{
    public class PagedList<T> : IPagedList<T>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public long TotalPages { get; set; }
        public long TotalResults { get; set; }

        public List<T> Items { get; set; }
        public bool IsEmpty => !Items.Any();

        public PagedList()
        {
            Items = new List<T>();
        }

        public PagedList(List<T> items, int page, int limit, long totalPages, long totalResults)
        {
            Items = items;
            Page = page;
            Limit = limit;
            TotalPages = totalPages;
            TotalResults = totalResults;
        }
    }
}