using System;
using MerchandiseService.Domain.Exceptions.RequestMerchAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public class RequestMerch : Entity
    {
        public RequestMerch(RequestNumber requestNumber,
                            EmployeeName employeeName,
                            ItemName itemName, 
                            Item itemType, 
                            ClothingSize size, 
                            Quantity quantity)
        {
            RequestNumber = requestNumber;
            EmployeeName = employeeName;
            ItemName = itemName;
            ItemType = itemType;
            SetClothingSize(size);
            SetQuantity(quantity);
            IssueStatus = IssueStatus.InWork;
        }
        
        public RequestMerch(RequestNumber requestNumber,
                            EmployeeName employeeName, 
                            ItemName itemName, 
                            Item itemType, 
                            Quantity quantity)
        {
            RequestNumber = requestNumber;
            EmployeeName = employeeName;
            ItemName = itemName;
            ItemType = itemType;
            SetClothingSize(null);
            SetQuantity(quantity);
            IssueStatus = IssueStatus.InWork;
        }

        public RequestNumber RequestNumber { get; }

        public EmployeeName EmployeeName { get; }

        public ItemName ItemName { get; }

        public Item ItemType { get; }
        
        public ClothingSize ClothingSize { get; private set; }
        
        public Quantity Quantity { get; private set; }

        public IssueStatus IssueStatus { get; set; }

        public bool IssuedMerch()
        {
            // Поиск в БД, выдавался ли мерч сотруднику
            return true;
        }

        public void SetClothingSize(ClothingSize size)
        {
            if (size is not null && (
                    ItemType.Type.Equals(RequestMerchAggregate.ItemType.TShirt) ||
                    ItemType.Type.Equals(RequestMerchAggregate.ItemType.Sweatshirt)))
                ClothingSize = size;
            else if (size is null && !(
                    ItemType.Type.Equals(RequestMerchAggregate.ItemType.TShirt) ||
                    ItemType.Type.Equals(RequestMerchAggregate.ItemType.Sweatshirt)))
                ClothingSize = null;
            else
            {
                throw new RequestMerchSizeException($"Wrong size for {ItemType.Type.Name}.");
            }
        }
        
        public void SetQuantity(Quantity value)
        {
            if (value.Value <= 0)
                throw new NegativeValueException($"The quantity cannot be less than or equal to zero.");

            Quantity = value;
        }
    }
}