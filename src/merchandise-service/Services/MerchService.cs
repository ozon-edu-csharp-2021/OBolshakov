using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using merchandise_service.Models;

namespace merchandise_service.Services
{
    public class MerchService : IMerchService
    {
        private readonly List<MerchItem> _merch = new List<MerchItem>
        {
            new MerchItem(1, "Мерч1", 1),
            new MerchItem(2, "Мерч2", 2),
            new MerchItem(3, "Мерч3", 5)
        };

        public Task<List<MerchItem>> GetAll(CancellationToken _) => Task.FromResult(_merch);

        public Task<MerchItem> GetById(long itemId, CancellationToken _)
        {
            var merch = _merch.FirstOrDefault(x => x.ItemId == itemId);
            return Task.FromResult(merch);
        }

        public Task<MerchItem> Add(MerchItemCreationModel merch, CancellationToken _)
        {
            var itemId = _merch.Max(x => x.ItemId) + 1;
            var newMerch = new MerchItem(itemId, merch.ItemName, merch.Quantity);
            _merch.Add(newMerch);
            return Task.FromResult(newMerch);
        }
    }
}