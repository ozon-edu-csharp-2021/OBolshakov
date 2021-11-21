using System.Collections.Generic;
using MerchandiseService.Infrastructure.Models;

namespace MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses
{
    public class GetAllRequestMerchQueryResponse : IItemsModel<RequestMerchDto>
    {
        public IReadOnlyList<RequestMerchDto> Items { get; set; }
    }
}