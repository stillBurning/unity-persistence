using System;

namespace Assets.Scripts.Persistance.Exceptions
{
    public class SaveNotFoundException : Exception
    {
        public SaveNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
