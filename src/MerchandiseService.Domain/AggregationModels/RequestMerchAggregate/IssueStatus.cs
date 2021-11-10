using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public class IssueStatus : Enumeration
    {
        public static IssueStatus InWork = new(1, "InQueue");
        public static IssueStatus Done = new(1, "Done");
        
        public IssueStatus(int id, string name) : base(id, name)
        {
        }
    }
}