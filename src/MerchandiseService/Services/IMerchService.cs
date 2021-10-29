using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services
{
    public interface IMerchService
    {
        Task<List<MerchItem>> GetAll(CancellationToken token);

        Task<MerchItem> GetById(long itemId, CancellationToken _);
        
        Task<MerchItem> Add(MerchItemCreationModel stockItem, CancellationToken _);
    }
}