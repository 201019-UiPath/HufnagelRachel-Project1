using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public class InventoryServices
    {
        private IInventoryRepo inventRepo;

        public InventoryServices(IInventoryRepo inventRepo) {
            this.inventRepo = inventRepo;
        }

        public void AddInventory(Inventory inventory) 
        {
            inventRepo.AddToInventory(inventory); 
        }

        public void UpdateInventory(Inventory inventory) 
        {
            inventRepo.UpdateInventory(inventory);
        }

        public Inventory GetInventoryItemByInventoryId(int intentoryId)
        {
            Inventory inventory = inventRepo.GetInventoryItemByInventoryId(intentoryId);
            return inventory;
        }

        public Inventory GetInventoryItemByLocationId(int locationId) 
        {
            Inventory inventory = inventRepo.GetInventoryItemByLocationId(locationId);
            return inventory;
        }

        public Inventory GetItemByLocIdStickId(int locId, int stickId)
        {
            Inventory inventory = inventRepo.GetInventoryByLocIdStickId(locId, stickId);
            return inventory;
        }

        public List<Inventory> GetAllOfInventoryByInventoryId(int inventoryId)
        {
            List<Inventory> inventory = inventRepo.GetAllOfInventoryByInventoryId(inventoryId);
            return inventory;
        }

        public List<Inventory> GetAllOfInventoryByLocationId (int locationId) 
        {
            List<Inventory> inventoryAtLocation = inventRepo.GetAllOfInventoryByLocationId(locationId);
            return inventoryAtLocation;
        }

        public void DeleteInventory(Inventory inventory) 
        {
            inventRepo.DeleteInventory(inventory);
        }
    }
}