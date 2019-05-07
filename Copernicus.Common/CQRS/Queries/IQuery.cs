namespace Copernicus.Common.CQRS.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<TQuery> : IQuery
    {
    }
}