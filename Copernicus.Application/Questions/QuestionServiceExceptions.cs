using Copernicus.Common.Types;

namespace Copernicus.Application.Questions
{
    public static class QuestionServiceExceptions
    {
        public class NotFound : ServiceException
        {
            public NotFound() : base(ErrorCodes.UserNotFound, "Question not found.")
            {
            }
        }

        public class AlreadyExists : ServiceException
        {
            public AlreadyExists() : base(ErrorCodes.UserAlreadyCreated, "That question already exists.")
            {
            }
        }
    }
}