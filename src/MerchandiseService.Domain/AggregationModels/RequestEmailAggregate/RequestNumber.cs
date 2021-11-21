namespace MerchandiseService.Domain.AggregationModels.RequestEmailAggregate
{
    public class RequestNumber
    {
        public RequestNumber(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}