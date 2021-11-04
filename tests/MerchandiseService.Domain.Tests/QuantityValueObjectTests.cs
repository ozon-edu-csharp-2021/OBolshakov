using System;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class QuantityValueObjectTests
    {
        [Fact]
        public void CreateQuantityInstanceSuccess()
        {
            var quantity = 10;

            var result = new Quantity(quantity);

            Assert.Equal(quantity, result.Value);
        }
    }
}