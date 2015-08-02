using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    /// <summary>
    ///   Exception thrown when battle.net community API website returns an error message
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        /// <param name="message"> message </param>
        public ApiException(string message) : base(message)
        {
        }

        /// <summary>
        ///   create a new instance of Apiexception
        /// </summary>
        /// <param name="message"> message </param>
        /// <param name="inner"> exception that cause this </param>
        public ApiException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        ///   Constructor. Initializes a new instance of ApiException class
        /// </summary>
        /// <param name="error"> Api error </param>
        /// <param name="httpStatus"> HTTP response status </param>
        /// <param name="inner"> Inner exception that triggered the exception </param>
        public ApiException(ApiError error, HttpStatusCode httpStatus, Exception inner)
            : base($"The server returned HTTP status: {httpStatus} with reason: {error?.Reason ?? "No reason"}", inner)
        {
            ApiError = error;
            HttpStatus = httpStatus;
        }

        /// <summary>
        ///   HTTP response code returned by Blizzard's community API website
        /// </summary>
        public HttpStatusCode HttpStatus { get; }
        
        /// <summary>
        ///   Deserialized error returned by Blizzard's community API website
        /// </summary>
        public ApiError ApiError { get; }
    }
}
