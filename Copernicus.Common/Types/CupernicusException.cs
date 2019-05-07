using System;

namespace Copernicus.Common.Types
{
    public class CupernicusException : Exception
    {
        public readonly string Code;

        public CupernicusException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}