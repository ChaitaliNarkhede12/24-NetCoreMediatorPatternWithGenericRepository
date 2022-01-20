using ApplicationLayer.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class InventoryAppService : IInventoryAppService
    {
        private readonly IGenericRepository<Inventory,int> _inventoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inventoryRepository"></param>
        public InventoryAppService(IGenericRepository<Inventory,int> inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        ///// <summary>
        ///// Get Inventory List
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IEnumerable<Inventory>> GetInventoryList()
        //{
        //    try
        //    {
        //        var result = await _inventoryRepository.Get().ConfigureAwait(false);
        //        if (result == null)
        //        {
        //            throw new Exception("GetInventoryList - List is empty");
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetInventoryList - " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Get inventory list using expression
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<Inventory>> GetInventoryByExpression(Expression<Func<Inventory, bool>> predicate)
        //{
        //    try
        //    {
        //        var result = await _inventoryRepository.Get(predicate).ConfigureAwait(false);

        //        if (result == null)
        //        {
        //            throw new Exception("GetInventoryByExpression- No item found");
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetInventoryByExpression - " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Get inventory details by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<Inventory> GetInventoryById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        throw new Exception("GetInventoryById - Inventory id should be greater than 0");
        //    }
        //    try
        //    {
        //        var result = await _inventoryRepository.GetById(id);

        //        if (result == null)
        //        {
        //            throw new Exception($"GetInventoryById - No record found against id - {id}");
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetInventoryById - " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Save inventory data
        ///// </summary>
        ///// <param name="inventory"></param>
        ///// <returns></returns>

        //public async Task<int> AddInventory(Inventory inventory)
        //{
        //    if (inventory == null)
        //    {
        //        throw new Exception("AddInventory - Inventory object is null");
        //    }

        //    try
        //    {
        //        inventory.CreatedDate = DateTime.Now;
        //        await this._inventoryRepository.Add(inventory);
        //        var result = await _inventoryRepository.SaveChangesAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("AddInventory - " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Update inventory data
        ///// </summary>
        ///// <param name="inventory"></param>
        ///// <returns></returns>

        //public async Task<int> UpdateInventory(Inventory inventory)
        //{
        //    if (inventory.InventoryId <= 0)
        //    {
        //        throw new Exception("UpdateInventory - Inventory id should be greater than 0");
        //    }

        //    try
        //    {
        //        this._inventoryRepository.Update(inventory);
        //        var result = await _inventoryRepository.SaveChangesAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("UpdateInventory - " + ex.Message);
        //    }

        //}

        /// <summary>
        /// Get Inventory List
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Inventory>> GetInventoryList()
        {
            try
            {
                var result = await _inventoryRepository.GetAll().ConfigureAwait(false);
                if (result == null)
                {
                    throw new Exception("GetInventoryList - List is empty");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("GetInventoryList - " + ex.Message);
            }
        }

        /// <summary>
        /// Get inventory list using expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Inventory>> GetInventoryByExpression(Expression<Func<Inventory, bool>> predicate)
        {
            try
            {
                var result = await _inventoryRepository.GetByExpression(predicate);

                if (result == null)
                {
                    throw new Exception("GetInventoryByExpression- No item found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("GetInventoryByExpression - " + ex.Message);
            }
        }

        /// <summary>
        /// Get inventory details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Inventory> GetInventoryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("GetInventoryById - Inventory id should be greater than 0");
            }
            try
            {
                var result = await _inventoryRepository.GetById(id);

                if (result == null)
                {
                    throw new Exception($"GetInventoryById - No record found against id - {id}");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("GetInventoryById - " + ex.Message);
            }
        }

        /// <summary>
        /// Save inventory data
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>

        public async Task<int> AddInventory(Inventory inventory)
        {
            if (inventory == null)
            {
                throw new Exception("AddInventory - Inventory object is null");
            }

            try
            {
                inventory.CreatedDate = DateTime.Now;
                await this._inventoryRepository.AddAsync(inventory);
                var result = await _inventoryRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("AddInventory - " + ex.Message);
            }
        }

        /// <summary>
        /// Update inventory data
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>

        public async Task<int> UpdateInventory(Inventory inventory)
        {
            if (inventory.InventoryId <= 0)
            {
                throw new Exception("UpdateInventory - Inventory id should be greater than 0");
            }

            try
            {
                this._inventoryRepository.Update(inventory);
                var result = await _inventoryRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateInventory - " + ex.Message);
            }

        }

        public async Task<int> DeleteInventory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("DeleteInventory - Inventory id should be greater than 0");
            }
            try
            {
                var data = this._inventoryRepository.RemoveById(id);
                var result = await _inventoryRepository.SaveChangesAsync();
                return result;

                //var entity = this._inventoryRepository.GetById(id).GetAwaiter().GetResult();
                //this._inventoryRepository.Remove(entity);

                //var result = await _inventoryRepository.SaveChangesAsync();
                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteInventory - " + ex.Message);
            }
        }
    }
}
