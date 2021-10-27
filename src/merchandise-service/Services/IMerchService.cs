using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using merchandise_service.Models;

namespace merchandise_service.Services
{
    public interface IMerchService
    {
        Task<List<MerchItem>> GetAll(CancellationToken token);

        Task<MerchItem> GetById(long itemId, CancellationToken _);
        
        Task<MerchItem> Add(MerchItemCreationModel stockItem, CancellationToken _);
    }
}