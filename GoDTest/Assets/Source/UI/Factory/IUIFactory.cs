using Source.Data.Inventory;

namespace Source.UI.Factory
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        UIInventory CreateInventory(InventoryData inventoryData);
        void CreateButtons();
    }
}