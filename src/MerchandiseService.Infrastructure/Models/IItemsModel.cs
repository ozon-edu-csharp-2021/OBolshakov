using System.Collections.Generic;

namespace MerchandiseService.Infrastructure.Models
{
    public interface IItemsModel<T> 
        where T : class
    {
        IReadOnlyList<T> Items { get; set; }
    }
}