using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Exceptions.IssueRequestAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.IssueRequestAggregate
{
    public class IssueRequest : Entity
    {
        public IssueRequest(RequestNumber requestNumber, Availability availability, IReadOnlyList<ItemName> itemCollection)
        {
            RequestNumber = requestNumber;
            Availability = availability;
            ItemCollection = itemCollection;
        }
        
        public RequestNumber RequestNumber { get; }

        public Availability Availability { get; private set; }

        public IReadOnlyList<ItemName> ItemCollection { get; }
        
        public void CheckAvailabilityMerchInStock(Availability availability)
        {
            if (Availability.Equals(AggregationModels.IssueRequestAggregate.Availability.InStock))
                throw new IssueRequestStatusException($"The merch is already reserved in the warehouse.");
            
            Availability = availability;
        }
    }
}