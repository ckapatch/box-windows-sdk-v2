using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box.V2.Exceptions
{
    public class AccessTokenExpiredException : Exception
    {
        /// <summary>
        /// Instantiates a new BoxException with the provided message and provided inner Exception
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception to be wrapped</param>
        public AccessTokenExpiredException(string message) : base(message) { }

        /// <summary>
        /// Instantiates a new BoxException with the provided message and provided inner Exception
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception to be wrapped</param>
        public AccessTokenExpiredException(string message, Exception innerException) : base(message, innerException) { }

    }
}
