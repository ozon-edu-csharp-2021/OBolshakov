using System;

namespace MerchandiseService.Domain.Exceptions.IssueRequestAggregate
{
    public class IssueRequestStatusException : Exception
    {
        public IssueRequestStatusException(string message) : base(message)
        {
            
        }
        
        public IssueRequestStatusException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}