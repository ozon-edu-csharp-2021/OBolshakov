using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.RequestEmailAggregate;
using MerchandiseService.Infrastructure.Commands.CreateRequestEmail;

namespace MerchandiseService.Infrastructure.Handlers.RequestEmailAggregate
{
    public class CreateRequestEmailCommandHandler : IRequestHandler<CreateRequestEmailCommand>
    {
        public readonly IRequestEmailRepository _requestEmailRepository;
        
        public CreateRequestEmailCommandHandler(IRequestEmailRepository deliveryRequestRepository)
        {
            _requestEmailRepository = deliveryRequestRepository ?? 
                                      throw new ArgumentNullException($"{nameof(deliveryRequestRepository)}");
        }
        
        public async Task<Unit> Handle(CreateRequestEmailCommand request, CancellationToken cancellationToken)
        {
            var requestEmail = new RequestEmail(
                null,
                Email.Create(request.Email),
                new TitleMessage(request.TitleMessage),
                new Message(request.Message));
            
            // Отправка email дальше

            await _requestEmailRepository.CreateAsync(requestEmail, cancellationToken);
            await _requestEmailRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}