using System.Collections.Generic;
using System.Threading.Tasks;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Base;

namespace Ordering.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        // As this is custom business, we are putting this here instead of IRepository.
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
