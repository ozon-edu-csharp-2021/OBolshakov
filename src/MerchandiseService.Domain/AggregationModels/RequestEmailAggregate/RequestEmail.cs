using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestEmailAggregate
{
    public class RequestEmail : Entity
    {
        public RequestEmail(RequestNumber requestNumber,
                            Email employeeName,
                            TitleMessage itemName,
                            Message itemType)
        {
            RequestNumber = requestNumber;
            Email = employeeName;
            TitleMessage = itemName;
            Message = itemType;
        }

        public RequestNumber RequestNumber { get; }

        public Email Email { get; }
         
        public TitleMessage TitleMessage { get; }

        public Message Message { get; }

        public bool IssuedMerch()
        {
            // Поиск в БД, выдавался ли мерч сотруднику
            return true;
        }
    }
}