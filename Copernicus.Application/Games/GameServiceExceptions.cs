using Copernicus.Common.Types;

namespace Copernicus.Application.Games
{
    public static class GameServiceExceptions
    {
        public class NotFound : ServiceException
        {
            public NotFound() : base(ErrorCodes.GameNotFound, "Game not found.")
            {
            }
        }

        public class AlreadyExists : ServiceException
        {
            public AlreadyExists() : base(ErrorCodes.GameAlreadyCreated, "That Game already exists.")
            {
            }
        }

        public class NotCreator : ServiceException
        {
            public NotCreator() : base(ErrorCodes.GameNotCreator, "You aren't creator of that game.")
            {
            }
        }

        public class NotMember : ServiceException
        {
            public NotMember() : base(ErrorCodes.GameNotMember, "You aren't member of that game.")
            {
            }
        }
        public class AlreadyMember : ServiceException
        {
            public AlreadyMember() : base(ErrorCodes.GameAlreadyMember, "You are member already.")
            {
            }
        }

        public class NoMoreQuestions : ServiceException
        {
            public NoMoreQuestions() : base(ErrorCodes.GameNoMoreQuestions, "We don't have any next questions.")
            {
            }
        }

        public class AnswerSequenceInvalid : ServiceException
        {
            public AnswerSequenceInvalid() : base(
                ErrorCodes.GameAnswerSequenceInvalid,
                "You can't answer on that question."
            )
            {
            }
        }

        public class AlreadyAnswered : ServiceException
        {
            public AlreadyAnswered() : base(
                ErrorCodes.GameAlreadyAnswered,
                "You already answer on that question."
            )
            {
            }
        }
    }
}