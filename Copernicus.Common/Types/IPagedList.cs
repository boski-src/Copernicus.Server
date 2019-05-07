using System.Collections.Generic;

namespace Copernicus.Common.Types
{
    public interface IPagedList<T>
    {
        int Page { get; set; }
        int Limit { get; set; }
        long TotalPages { get; set; }
        long TotalResults { get; set; }
        List<T> Items { get; set; }
        bool IsEmpty { get; }
    }
}