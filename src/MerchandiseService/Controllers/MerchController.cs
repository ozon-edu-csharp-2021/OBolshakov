using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Infrastructure.Commands.ReservationMerch;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate;
using MerchandiseService.Models;
using MerchandiseService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchService _merchService;
        private readonly IMediator _mediator;

        public MerchController(IMerchService merchService, IMediator mediator)
        {
            _merchService = merchService;
            _mediator = mediator;
        }
        
        /// <summary>
        /// Ищет все merch.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var merchService = await _merchService.GetAll(token);
            return Ok(merchService);
        }
        
        /// <summary>
        /// Ищет merch по id.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<string>> GetById(long id, CancellationToken token)
        {
            var issueStatus = new GetIssueStatusQuery()
            {
                RequestNumber = id
            };
            
            var result = await _mediator.Send(issueStatus, token);

            return result;
        }

        /// <summary>
        /// Добавляет merch.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchItem>> AddReservation(MerchItemCreationModel postViewModel, CancellationToken token)
        {
            var createReservationMerchCommand = new ReservationMerchCommand()
            {
                EmployeeName = postViewModel.EmployeeName,
                ItemName = postViewModel.ItemName,
                ItemType = postViewModel.ItemType,
                ClothingSize = postViewModel.ClothingSize,
                Quantity = postViewModel.Quantity
            };

            var result = await _mediator.Send(createReservationMerchCommand, token);
            
            return Ok(createReservationMerchCommand);
        }
    }
}