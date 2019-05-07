namespace Copernicus.Common.Types
{
    public class ServiceException : CupernicusException
    {
        public ServiceException(string code, string message) : base(code, message)
        {
        }
    }
}