using System;

namespace KBS.Exceptions
{
    public class NotImplementedByDesignException : NotImplementedException
    {
        public NotImplementedByDesignException() : base()
        {
        }

        public NotImplementedByDesignException(string message) : base(message)
        {
        }

        public NotImplementedByDesignException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
