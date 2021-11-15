﻿namespace MerchandiseService.HttpModels
{
    public class MerchResponse
    {
        public string EmployeeName { get; init; }

        public string ItemName { get; init; }

        public int ItemType { get; init; }
        
        public int ClothingSize { get; init; }
        
        public int Quantity { get; init; }

        public int IssueStatus { get; init; }
    }
}