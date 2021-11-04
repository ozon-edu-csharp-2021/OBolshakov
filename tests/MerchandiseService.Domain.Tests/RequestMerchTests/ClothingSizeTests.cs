using System;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Exceptions.RequestMerchAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests.RequestMerchTests
{
    public class ClothingSizeTests
    {
        [Fact]
        public void SetCorrectClothingSize()
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
            Assert.Equal(ClothingSize.S, requestMerch.ClothingSize);
        }
        
        [Fact]
        public void SetNullClothingSizeForSubject()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("Pen"),
                new Item(ItemType.Pen),
                new Quantity(10));
        
            // Act
        
            //Assert
            Assert.Null(requestMerch.ClothingSize);
        }
        
        [Fact]
        public void SetNullClothingSize()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("Sweatshirt"),
                new Item(ItemType.Sweatshirt),
                new Quantity(10));
        
            // Act
        
            //Assert
            Assert.Throws<RequestMerchSizeException>(() => requestMerch.ClothingSize);
        }
        
        [Fact]
        public void SetClothingSizeForSubject()
        {
            // Arrange
            var requestMerch = new RequestMerch(
                new RequestNumber(15),
                new EmployeeName("Oleg Bolshakov"),
                new ItemName("TShirt"),
                new Item(ItemType.Pen),
                ClothingSize.XXL,
                new Quantity(10));
        
            // Act
        
            //Assert
            Assert.Throws<RequestMerchSizeException>(() => requestMerch);
        }
    }
}