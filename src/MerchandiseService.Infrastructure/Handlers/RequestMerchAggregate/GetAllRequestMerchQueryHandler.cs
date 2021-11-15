using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Infrastructure.Models;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class GetAllRequestMerchQueryHandler : IRequestHandler<GetAllRequestMerchQuery, GetAllRequestMerchQueryResponse>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public GetAllRequestMerchQueryHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        
        public async Task<GetAllRequestMerchQueryResponse> Handle(GetAllRequestMerchQuery request, CancellationToken cancellationToken)
        {
            var items = await _requestMerchRepository.GetAllAsync(cancellationToken);
            return new GetAllRequestMerchQueryResponse
            {
                Items = items.Select(item => new RequestMerchDto
                {
                    EmployeeName = item.EmployeeName.Value,
                    ItemName = item.ItemName.Value,
                    ItemType = item.ItemType.Type.Id,
                    ClothingSize = item.ClothingSize.Id,
                    Quantity = item.Quantity.Value,
                    IssueStatus = item.IssueStatus.Id,
                }).ToList()
            };
        }
    }
}