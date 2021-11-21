using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateRequestEmail
{
    public class CreateRequestEmailCommand : IRequest
    {
        public string Email { get; init; }
         
        public string TitleMessage { get; init; }

        public string Message { get; init; }
    }
}