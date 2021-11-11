using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.ReservationMerch;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class FindMerchQueryHandler : IRequestHandler<GetIssueStatusQuery, string>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public FindMerchQueryHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        
        public async Task<string> Handle(GetIssueStatusQuery request, CancellationToken cancellationToken)
        {
            var merch = await _requestMerchRepository.FindByIdAsync(request.RequestNumber, cancellationToken);
            if (merch is null)
                throw new Exception($"There is no request with this {request.RequestNumber} ID.");
            
            return $"Status is {merch.IssueStatus}";
        }
    }
}