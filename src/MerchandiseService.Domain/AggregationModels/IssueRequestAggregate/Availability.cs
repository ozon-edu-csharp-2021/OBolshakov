using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.IssueRequestAggregate
{
    public class Availability : Enumeration
    {
        public static Availability InStock = new(0, "InStock");
        public static Availability OutStock = new(1, "OutStock");
        
        public Availability(int id, string name) : base(id, name)
        {
        }
    }
}