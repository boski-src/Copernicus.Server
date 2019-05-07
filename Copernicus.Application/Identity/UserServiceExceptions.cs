using Copernicus.Common.Types;

namespace Copernicus.Application.Identity
{
    public static class UserServiceExceptions
    {
        public class NotFound : ServiceException
        {
            public NotFound() : base(ErrorCodes.UserNotFound, "User not found.")
            {
            }
        }

        public class AlreadyExists : ServiceException
        {
            public AlreadyExists() : base(ErrorCodes.UserAlreadyCreated, "That user already exists.")
            {
            }
        }

        public class EmailAlreadyUsed : ServiceException
        {
            public EmailAlreadyUsed() : base(ErrorCodes.UserEmailUsed, "That email already used.")
            {
            }
        }
    }
}