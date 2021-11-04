using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Infrastructure.Commands.GiveMerch;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class GiveMerchCommandHandler : IRequest<GiveMerchCommand>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public GiveMerchCommandHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        
        public async Task<Unit> Handle(GiveMerchCommand request, CancellationToken cancellationToken)
        {
            var merchItem = await _requestMerchRepository.FindByIdAsync(request.RequestNumber, cancellationToken);
            if (merchItem is null)
                throw new Exception($"Not found with id {request.RequestNumber}");
            
            merchItem.GiveMerch(request.Quantity);
            await _requestMerchRepository.UpdateAsync(merchItem, cancellationToken);
            await _requestMerchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}