using System;

namespace SIS.HTTP.DiffApproach.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionMessage
            = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(BadRequestExceptionMessage)
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
