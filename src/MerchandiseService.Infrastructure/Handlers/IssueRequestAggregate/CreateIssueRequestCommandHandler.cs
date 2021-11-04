using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.IssueRequestAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Infrastructure.Commands.CreateIssueRequest;

namespace MerchandiseService.Infrastructure.Handlers.IssueRequestAggregate
{
    public class CreateIssueRequestCommandHandler
    {
        private readonly IIssueRequestRepository _issueRequestRepository;
        
        public CreateIssueRequestCommandHandler(IIssueRequestRepository issueRequestRepository)
        {
            _issueRequestRepository = issueRequestRepository ?? 
                                      throw new ArgumentNullException($"{nameof(issueRequestRepository)}");
        }

        public async Task<Unit> Handle(CreateIssueRequestCommand request, CancellationToken cancellationToken)
        {
            var issueRequest = new IssueRequest(
                null,
                Availability.OutStock,
                request.ItemCollection.Select(it => new ItemName(it)).ToList());

            // Тут запрос к stock api для получения информации о наличии мерча

            await _issueRequestRepository.CreateAsync(issueRequest, cancellationToken);
            await _issueRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}