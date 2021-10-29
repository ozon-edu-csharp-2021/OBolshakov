using System.Threading;
using System.Threading.Tasks;
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

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
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
        public async Task<ActionResult<MerchItem>> GetById(long id, CancellationToken token)
        {
            var merchService = await _merchService.GetById(id, token);
            if (merchService is null)
            {
                return NotFound();
            }

            return merchService;
        }

        /// <summary>
        /// Добавляет merch.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchItem>> Add(MerchItemCreationModel postViewModel, CancellationToken token)
        {
            var createdMerch = await _merchService.Add(new MerchItemCreationModel
            {
                ItemName = postViewModel.ItemName,
                Quantity = postViewModel.Quantity
            }, token);
            return Ok(createdMerch);
        }
    }
}