using MerchandiseService.Domain.AggregationModels.RequestEmailAggregate;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Exceptions.ReuqestEmailAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests.RequestEmailTests
{
    public class CreateEmailTests
    {
        [Fact]
        public void SetInvalidValueEmail()
        {
            // Arrange
            
            // Act
        
            //Assert
            Assert.Throws<InvalidValueException>(() => Email.Create("test"));
        }
        
        [Fact]
        public void SetCorrectValueEmail()
        {
            // Arrange
            
            // Act
        
            //Assert
            Assert.Equal("test@mail.ru", Email.Create("test@mail.ru").Value);
        }
    }
}