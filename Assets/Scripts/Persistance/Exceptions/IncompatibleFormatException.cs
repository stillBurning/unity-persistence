using System;

namespace Assets.Scripts.Persistance.Exceptions
{
    public class IncompatibleFormatException : Exception
    {
        public IncompatibleFormatException(string message)
            : base(message)
        {
        }

        public IncompatibleFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
