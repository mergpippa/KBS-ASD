using System;

namespace KBS.MessageBus.Exceptions
{
    internal class InvalidEnvironmentVariableException : Exception
    {
        public InvalidEnvironmentVariableException(string environmentVariableName) :
            base($"Environment variable `{environmentVariableName}` invalid or missing")
        { }

        public InvalidEnvironmentVariableException() : base()
        { }

        public InvalidEnvironmentVariableException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
