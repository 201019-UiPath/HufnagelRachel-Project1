using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface IInventoryRepo
    {
        void AddToInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory);
        Inventory GetInventoryItemByInventoryId(int intentoryId);
        Inventory GetInventoryItemByLocationId(int locationId);
        Inventory GetInventoryByLocIdStickId (int locId, int stickId);
        List<Inventory> GetAllOfInventoryByInventoryId(int inventoryId);
        List<Inventory> GetAllOfInventoryByLocationId(int locationId);
        void DeleteInventory(Inventory inventory);

        void SaveChanges();
    }
}