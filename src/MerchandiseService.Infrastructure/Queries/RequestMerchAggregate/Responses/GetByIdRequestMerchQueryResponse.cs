using System.Collections.Generic;
using MerchandiseService.Infrastructure.Models;

namespace MerchandiseService.Infrastructure.Queries.RequestMerchAggregate.Responses
{
    public class GetByIdRequestMerchQueryResponse
    {
        public RequestMerchDto Items { get; set; }
    }
}