using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.ReservationMerch;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class ReservationMerchCommandHandler : IRequestHandler<ReservationMerchCommand, string>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public ReservationMerchCommandHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        
        public async Task<string> Handle(ReservationMerchCommand request, CancellationToken cancellationToken)
        {
            var newRequestMerch = new RequestMerch(
                null,
                new EmployeeName(request.EmployeeName),
                new ItemName(request.ItemName),
                new Item(ItemType.GetAll<ItemType>().FirstOrDefault(it => it.Id.Equals(request.ItemType))),
                Enumeration
                    .GetAll<ClothingSize>()
                    .FirstOrDefault(it => it.Id.Equals(request.ClothingSize)),
                new Quantity(request.Quantity)
            );
            
            if (newRequestMerch.IssuedMerch())
            {
                throw new Exception("Merch has already been issued.");
            }
            
            // Обращение к Stock api для получения информации о наличии мерча
            // Если мерч есть - резервируем и меняем статус на IssueStatus.Done
            // Иначе IssueStatus.InWork
            newRequestMerch.IssueStatus = IssueStatus.Done;
            
            await _requestMerchRepository.CreateAsync(newRequestMerch, cancellationToken);
            await _requestMerchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return $"The issue of merch is {newRequestMerch.IssueStatus.Name}";
        }
    }
}