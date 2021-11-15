using MediatR;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses;

namespace MerchandiseService.Infrastructure.Queries.RequestMerchAggregate
{
    public class GetAllRequestMerchQuery : IRequest<GetAllRequestMerchQueryResponse>
    {
    }
}