using System.Runtime.Serialization;

namespace EDNeutronRouterPlugin.Exceptions
{
    [Serializable]
    public class InvalidEndSystemException : Exception
    {
        public InvalidEndSystemException()
        {
        }

        public InvalidEndSystemException(string? message) : base(message)
        {
        }

        public InvalidEndSystemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidEndSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}