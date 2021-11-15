using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.HttpModels;
using MerchandiseService.Infrastructure.Commands.ReservationMerch;
using MerchandiseService.Infrastructure.Queries.RequestMerchAggregate;
using MerchandiseService.Models;
using MerchandiseService.Services;
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
        public async Task<MerchResponse[]> GetAll(CancellationToken token)
        {
            var merch = new GetAllRequestMerchQuery();
            
            var result = await _mediator.Send(merch, token);

            return result.Items.Select(item => new MerchResponse
            {
                EmployeeName = item.EmployeeName,
                ItemName = item.ItemName,
                ItemType = item.ItemType,
                ClothingSize = item.ClothingSize,
                Quantity = item.Quantity,
                IssueStatus = item.IssueStatus
            }).ToArray();
        }
        
        /// <summary>
        /// Ищет merch по id.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<MerchResponse>> GetById(long id, CancellationToken token)
        {
            var merch = new GetByIdRequestMerchQuery
            {
                RequestNumber = id
            };
            
            var result = await _mediator.Send(merch, token);

            return Ok(result);
        }

        /// <summary>
        /// Добавляет merch.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchResponse>> AddReservation(MerchItemCreationModel postViewModel, CancellationToken token)
        {
            var createReservationMerchCommand = new ReservationMerchCommand
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