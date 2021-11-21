namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
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