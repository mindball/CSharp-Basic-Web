using System;

namespace SIS.HTTP.DiffApproach.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorExceptionMessage 
            = "The Request was malformed or contains unsupported elements.";

        public InternalServerErrorException()
            :base(InternalServerErrorExceptionMessage)
        {
        }

        public InternalServerErrorException(string message) 
            : base(message)
        {
        }
    }
}
