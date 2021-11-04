using System;

namespace MerchandiseService.Domain.Exceptions.RequestMerchAggregate
{
    public class NotEnoughItemsException : Exception
    {
        public NotEnoughItemsException(string message) : base(message)
        {
            
        }
        
        public NotEnoughItemsException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}