namespace Copernicus.Core.Domain.Games
{
    public static class States
    {
        public const string Waiting = "waiting";
        public const string Started = "started";
        public const string Ended = "ended";

        public static bool IsValid(string value) => value == Waiting || value == Started || value == Ended;
    }
}