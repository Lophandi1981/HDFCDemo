using System;
using System.Runtime.Serialization;
using System.Web.Mvc.Filters;

namespace AuthTest.Code.Filters
{
    [Serializable]
    internal class AuthException : Exception
    {
        private AuthenticationContext filterContext;

        public AuthException()
        {
        }

        public AuthException(AuthenticationContext filterContext)
        {
            this.filterContext = filterContext;
        }

        public AuthException(string message) : base(message)
        {
        }

        public AuthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AuthenticationContext FilterContext { get { return filterContext; } }
    }
}