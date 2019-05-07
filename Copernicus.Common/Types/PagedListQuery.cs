namespace Copernicus.Common.Types
{
    public abstract class PagedListQuery : IPagedListQuery
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}