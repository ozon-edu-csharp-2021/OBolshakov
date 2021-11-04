using MediatR;

namespace MerchandiseService.Infrastructure.Commands.GiveMerch
{
    public class GiveMerchCommand : IRequest
    {
        public long RequestNumber { get; set; }
        public int Quantity { get; set; }
    }
}