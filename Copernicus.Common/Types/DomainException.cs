namespace Copernicus.Common.Types
{
    public class DomainException : CupernicusException
    {
        public DomainException(string message) : base("DOMAIN_VALIDATION", message)
        {
        }
    }
}