using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateIssueRequest
{
    public class CreateIssueRequestCommand : IRequest<int>
    {
        public IReadOnlyList<string> ItemCollection { get; set; }
    }
}