using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public class Quantity : ValueObject
    {
        public Quantity(int value)
        {
            Value = value;
        }

        public int Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public class QuantityValue : ValueObject
    {
        public QuantityValue(int? value)
        {
            Value = value;
        }

        public int? Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}