using System;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace MerchandiseService.Domain.Tests.RequestMerchTests
{
    public class GiveMerchTests
    {
        [Fact]
        public void GiveRequestMerch()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("TShirt"),
                new Item(ItemType.TShirt),
                ClothingSize.S,
                new Quantity(10));

            var quantityToGive = 5;
        
            // Act
            requestMerch.GiveMerch(quantityToGive);
        
            //Assert
            Assert.Equal(5, requestMerch.Quantity.Value);
        }

        [Fact]
        public void GiveRequestMerchNegativeValueSuccess()
        {
            //Arrange 
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("TShirt"),
                new Item(ItemType.TShirt),
                ClothingSize.S,
                new Quantity(10));
            
            var quantityToGive = 50;
            
            //Act
            
            //Assert
            Assert.Throws<ArgumentException>(() => requestMerch.GiveMerch(quantityToGive));
        }
    }
}