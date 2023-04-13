using System.Collections.Generic;
using Source.Data.Inventory;
using Source.Infrastructure.Services.PersistentProgress;
using Source.UI;
using Source.UI.Factory;

namespace Source.Controllers
{
    public class InventoryController : IInventoryController
    {
        private readonly InventoryData _inventoryData;
        private UIInventory _inventoryUI;
        private readonly IUIFactory _uiFactory;

        private InventoryController(IUIFactory uiFactory, IPersistentProgressService progressService)
        {
            _inventoryData = progressService.Progress.InventoryData;
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            CreateUI();
            UpdateUI(_inventoryData.ActualInventory());
            AddHandles();
        }

        public void CleanUp()
        {
            RemoveHandles();
        }


        private void HandleSwapItems(int itemIndex1, int itemIndex2)
        {
            _inventoryData.SwapItems(itemIndex1, itemIndex2);
        }

        private void HandleDragging(int itemIndex)
        {
            var item = _inventoryData.GetItem(itemIndex);
            if (item.IsEmpty)
                return;

            _inventoryUI.SetDataToDraggableItem(item.ItemData.Sprite, item.Count);
        }

        private void UpdateUI(Dictionary<int, InventorySlot> actualInventory)
        {
            _inventoryUI.ResetAllItemData();
            SetAllItemData(actualInventory);
        }

        private void SetAllItemData(Dictionary<int, InventorySlot> actualInventory)
        {
            foreach (var item in actualInventory)
                _inventoryUI.UpdateItemData(
                    item.Key,
                    item.Value.ItemData.Sprite,
                    item.Value.Count,
                    item.Value.IsLocked);
        }

        private void CreateUI()
        {
            _inventoryUI = _uiFactory.CreateInventory(_inventoryData);
            _inventoryUI.Initialize();
        }

        private void AddHandles()
        {
            _inventoryData.DataChanged += UpdateUI;
            _inventoryUI.StartDragging += HandleDragging;
            _inventoryUI.SwapItems += HandleSwapItems;
        }

        private void RemoveHandles()
        {
            _inventoryData.DataChanged -= UpdateUI;
            _inventoryUI.StartDragging -= HandleDragging;
            _inventoryUI.SwapItems -= HandleSwapItems;
        }
    }
}