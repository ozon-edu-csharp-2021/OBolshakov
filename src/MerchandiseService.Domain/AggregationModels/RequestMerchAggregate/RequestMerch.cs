using System;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Exceptions.RequestMerchAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public class RequestMerch : Entity
    {
        public RequestMerch(RequestNumber requestNumber, EmployeeName employeeName, ItemName itemName, Item itemType, ClothingSize size, Quantity quantity)
        {
            RequestNumber = requestNumber;
            EmployeeName = employeeName;
            ItemName = itemName;
            ItemType = itemType;
            SetClothingSize(size);
            SetQuantity(quantity);
        }
        
        public RequestMerch(RequestNumber requestNumber, EmployeeName employeeName, ItemName itemName, Item itemType, Quantity quantity)
        {
            RequestNumber = requestNumber;
            EmployeeName = employeeName;
            ItemName = itemName;
            ItemType = itemType;
            SetClothingSize(null);
            SetQuantity(quantity);
        }

        public RequestNumber RequestNumber { get; }

        public EmployeeName EmployeeName { get; }

        public ItemName ItemName { get; }

        public Item ItemType { get; }
        
        public ClothingSize ClothingSize { get; private set; }
        
        public Quantity Quantity { get; private set; }

        public void GiveMerch(int valueToGive)
        {
            if (valueToGive <= 0 || valueToGive > Quantity.Value)
                throw new ArgumentException($"{nameof(valueToGive)} invalid value");
            
            Quantity = new Quantity(Quantity.Value - valueToGive);
        }

        public void SetClothingSize(ClothingSize size)
        {
            if (size is not null && (
                ItemType.Type.Equals(ValueObjects.ItemType.TShirt) ||
                ItemType.Type.Equals(ValueObjects.ItemType.Sweatshirt)))
                ClothingSize = size;
            else if (size is null && (
                     ItemType.Type.Equals(ValueObjects.ItemType.TShirt) ||
                     ItemType.Type.Equals(ValueObjects.ItemType.Sweatshirt)))
                throw new RequestMerchSizeException($"The {ItemType.Type.Name} must have a size."); 
            else
            {
                throw new RequestMerchSizeException($"The {ItemType.Type.Name} cannot get size.");    
            }
        }
        
        private void SetQuantity(Quantity value)
        {
            if (value.Value < 0)
                throw new NegativeValueException($"{nameof(value)} value is negative");

            Quantity = value;
        }

        /*private void AddReachedMinimumDomainEvent(Sku sku)
        {
            var orderStartedDomainEvent = new ReachedMinimumStockItemsNumberDomainEvent(sku);

            this.AddDomainEvent(orderStartedDomainEvent);
        }*/
    }
}