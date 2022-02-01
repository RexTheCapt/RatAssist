using System.Runtime.Serialization;

namespace EDNeutronRouterPlugin.Exceptions
{
    [Serializable]
    public class InvalidStartSystemException : Exception
    {
        public InvalidStartSystemException()
        {
        }

        public InvalidStartSystemException(string? message) : base(message)
        {
        }

        public InvalidStartSystemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidStartSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}