using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface IInventoryServices
    {
        void AddInventory(Inventory inventory);
        void DeleteInventory(Inventory inventory);
        List<Inventory> GetAllOfInventoryByInventoryId(int inventoryId);
        List<Inventory> GetAllOfInventoryByLocationId(int locationId);
        Inventory GetInventoryItemByInventoryId(int intentoryId);
        Inventory GetInventoryItemByLocationId(int locationId);
        Inventory GetItemByLocIdStickId(int locId, int stickId);
        void UpdateInventory(Inventory inventory);
    }
}