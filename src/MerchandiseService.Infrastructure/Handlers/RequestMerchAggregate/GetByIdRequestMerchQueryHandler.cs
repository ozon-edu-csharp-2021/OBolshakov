using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Infrastructure.Models;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class GetByIdRequestMerchQueryHandler : IRequestHandler<GetByIdRequestMerchQuery, GetByIdRequestMerchQueryResponse>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public GetByIdRequestMerchQueryHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }

        public async Task<GetByIdRequestMerchQueryResponse> Handle(GetByIdRequestMerchQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestMerchRepository.FindByIdAsync(request.RequestNumber, cancellationToken);
            return new GetByIdRequestMerchQueryResponse
            {
                Items = new RequestMerchDto
                {
                    EmployeeName = result.EmployeeName.Value,
                    ItemName = result.ItemName.Value,
                    ItemType = result.ItemType.Id,
                    ClothingSize = result.ClothingSize.Id,
                    Quantity = result.Quantity.Value,
                    IssueStatus = result.IssueStatus.Id
                }
            };
        }
    }
}