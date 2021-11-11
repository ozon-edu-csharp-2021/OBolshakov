using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestEmailAggregate
{
    public class TitleMessage : ValueObject
    {
        public string Value { get; }
        
        public TitleMessage(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}