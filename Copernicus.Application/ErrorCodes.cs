namespace Copernicus.Application
{
    public static class ErrorCodes
    {
        public const string UserNotFound = "USER_NOT_FOUND";
        public const string UserAlreadyCreated = "USER_ALREADY_EXISTS";
        public const string UserNameUsed = "USER_NAME_USED";
        public const string UserEmailUsed = "USER_EMAIL_USED";

        public const string PlayerNotFound = "PLAYER_NOT_FOUND";

        public const string QuestionNotFound = "QUESTION_NOT_FOUND";
        public const string QuestionAlreadyCreated = "QUESTION_ALREADY_EXISTS";

        public const string GameNotFound = "GAME_NOT_FOUND";
        public const string GameAlreadyCreated = "GAME_ALREADY_EXISTS";
        public const string GameNotCreator = "GAME_NOT_CREATOR";
        public const string GameNotMember = "GAME_NOT_MEMBER";
        public const string GameAlreadyMember = "GAME_ALREADY_MEMBER";
        public const string GameAnswerSequenceInvalid = "GAME_ANSWER_ORDER_INVALID";
        public const string GameNoMoreQuestions = "GAME_NO_MORE_QUESTIONS";
        public const string GameAlreadyAnswered = "GAME_ALREADY_ANSWERED";
    }
}