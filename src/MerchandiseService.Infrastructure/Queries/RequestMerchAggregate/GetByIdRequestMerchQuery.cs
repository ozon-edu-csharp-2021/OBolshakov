using MediatR;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses;

namespace MerchandiseService.Infrastructure.Queries.RequestMerchAggregate
{
    public class GetByIdRequestMerchQuery : IRequest<GetByIdRequestMerchQueryResponse>
    {
        public long RequestNumber { get; set; }
    }
}