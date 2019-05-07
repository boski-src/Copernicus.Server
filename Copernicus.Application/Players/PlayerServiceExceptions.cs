using Copernicus.Common.Types;

namespace Copernicus.Application.Players
{
    public static class PlayerServiceExceptions
    {
        public class NotFound : ServiceException
        {
            public NotFound() : base(ErrorCodes.PlayerNotFound, "Player not found.")
            {
            }
        }
    }
}