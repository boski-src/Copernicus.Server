namespace Copernicus.Common.Types
{
    public interface IPagedListQuery
    {
        int Page { get; set; }
        int Limit { get; set; }
    }
}