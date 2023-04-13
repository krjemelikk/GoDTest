using System;
using Source.Data.Inventory;

namespace Source.Data
{
    [Serializable]
    public class Progress
    {
        public InventoryData InventoryData;

        public Progress(InventoryData inventoryData)
        {
            InventoryData = inventoryData;
        }
    }
}