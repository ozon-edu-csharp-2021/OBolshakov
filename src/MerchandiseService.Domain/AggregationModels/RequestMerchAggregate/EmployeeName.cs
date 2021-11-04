using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public class EmployeeName : ValueObject
    {
        public string Value { get; }
        
        public EmployeeName(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}