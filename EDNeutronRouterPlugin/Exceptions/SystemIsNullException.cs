using System.Runtime.Serialization;

namespace EDNeutronRouterPlugin.Exceptions
{
    [Serializable]
    public class SystemIsNullException : Exception
    {
        public SystemIsNullException()
        {
        }

        public SystemIsNullException(string? message) : base(message)
        {
        }

        public SystemIsNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SystemIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}