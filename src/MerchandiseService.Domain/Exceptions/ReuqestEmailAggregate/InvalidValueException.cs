using System;

namespace MerchandiseService.Domain.Exceptions.ReuqestEmailAggregate
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
            
        }
        
        public InvalidValueException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}