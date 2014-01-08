using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box.V2.Exceptions
{
    public class BoxRateLimitingException : Exception
    {

        public int RetryAfter { get; set; }

        /// <summary>
        /// Instantiates a new BoxException with the provided message
        /// </summary>
        /// <param name="message">The message for the exception</param>
        public BoxRateLimitingException(string message, int retryAfter) : base(message) { }

        /// <summary>
        /// Instantiates a new BoxException with the provided message and provided inner Exception
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception to be wrapped</param>
        public BoxRateLimitingException(string message, int retryAfter, Exception innerException) : base(message, innerException) { }
    }
}
