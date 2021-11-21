using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Exceptions.RequestMerchAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests.RequestMerchTests
{
    public class QuantityTests
    {
        [Fact]
        public void SetValidQuantity()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("Sweatshirt"),
                new Item(ItemType.Sweatshirt),
                ClothingSize.S,
                new Quantity(10));
        
            // Act
        
            //Assert
            Assert.Equal(10, requestMerch.Quantity.Value);
        }
        
        [Fact]
        public void SetNegativeQuantityValue()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("Sweatshirt"),
                new Item(ItemType.Sweatshirt),
                ClothingSize.S,
                new Quantity(10));
        
            // Act
        
            //Assert
            Assert.Throws<NegativeValueException>(() => requestMerch.SetQuantity(new Quantity(-10)));
        }
    }
}