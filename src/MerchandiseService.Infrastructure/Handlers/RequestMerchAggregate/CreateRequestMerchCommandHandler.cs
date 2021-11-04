using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateRequestMerch;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class CreateRequestMerchCommandHandler : IRequestHandler<CreateRequestMerchCommand, int>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public CreateRequestMerchCommandHandler(IRequestMerchRepository stockItemRepository)
        {
            _requestMerchRepository = stockItemRepository;
        }
        
        public async Task<int> Handle(CreateRequestMerchCommand request, CancellationToken cancellationToken)
        {
            var merchInDb = await _requestMerchRepository.FindByIdAsync(request.RequestNumber, cancellationToken);
            if (merchInDb is not null)
                throw new Exception($"Stock item with sku {request.RequestNumber} already exist");

            var newMerchItem = new RequestMerch(
                new RequestNumber(request.RequestNumber),
                new EmployeeName(request.EmployeeName),
                new ItemName(request.ItemName),
                new Item(ItemType.GetAll<ItemType>().FirstOrDefault(it => it.Id.Equals(request.ItemType))),
                Enumeration
                    .GetAll<ClothingSize>()
                    .FirstOrDefault(it => it.Id.Equals(request.ClothingSize)),
                new Quantity(request.Quantity)
            );

            var createResult = await _requestMerchRepository.CreateAsync(newMerchItem, cancellationToken);
            await _requestMerchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return newMerchItem.Id;
        }
    }
}