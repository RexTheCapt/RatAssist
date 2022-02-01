using System.Runtime.Serialization;

namespace EDNeutronRouterPlugin.Exceptions
{
    [Serializable]
    public class RouteIsNullException : Exception
    {
        public RouteIsNullException()
        {
        }

        public RouteIsNullException(string? message) : base(message)
        {
        }

        public RouteIsNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RouteIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}