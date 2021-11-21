using System;

namespace MerchandiseService.Domain.Exceptions.RequestMerchAggregate
{
    public class RequestMerchSizeException : Exception
    {
        public RequestMerchSizeException(string message) : base(message)
        {
            
        }
        
        public RequestMerchSizeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}