using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IInventoryAppService
    {
        Task<IEnumerable<Inventory>> GetInventoryList();
        Task<IEnumerable<Inventory>> GetInventoryByExpression(Expression<Func<Inventory, bool>> predicate);
        Task<Inventory> GetInventoryById(int id);
        Task<int> AddInventory(Inventory inventory);
        Task<int> UpdateInventory(Inventory inventory);
        Task<int> DeleteInventory(int id);

    }
}
