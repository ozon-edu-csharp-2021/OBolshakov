using MediatR;

namespace MerchandiseService.Infrastructure.Commands.ReservationMerch
{
    public class ReservationMerchCommand : IRequest<string>
    {
        public string EmployeeName { get; init; }

        public string ItemName { get; init; }

        public string ItemType { get; init; }
        
        public int ClothingSize { get; init; }
        
        public int Quantity { get; init; }
    }
}