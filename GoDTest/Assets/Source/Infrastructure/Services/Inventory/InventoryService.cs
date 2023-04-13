using System.Linq;
using Source.Data.Inventory;
using Source.Enums;
using Source.Infrastructure.Factory;
using Source.Infrastructure.Services.PersistentProgress;
using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryData _inventoryData;
        private readonly IItemFactory _itemFactory;

        public InventoryService(IPersistentProgressService progressService, IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
            _inventoryData = progressService.Progress.InventoryData;
        }

        public void AddItemStack(ItemTypeId itemId)
        {
            var itemData = _itemFactory.CreateItem(itemId);
            _inventoryData.AddItem(itemData, itemData.MaxStackSize);
        }

        public void AddRandomItem(params ItemTypeId[] itemIds)
        {
            var randomItem = itemIds.RandomElement();
            var itemData = _itemFactory.CreateItem(randomItem);
            _inventoryData.AddItem(itemData, 1);
        }

        public void UnlockSlot()
        {
            _inventoryData.UnlockSlot();
        }

        public void RemoveOneRandomAmmo()
        {
            var ammo = _inventoryData
                .Items
                .Where(x =>
                    x.ItemData != null &&
                    x.ItemData.GetType() == typeof(AmmoData));

            if (!ammo.Any())
            {
                Debug.LogWarning("Нет патронов");
                return;
            }

            _inventoryData.RemoveItem(ammo.RandomElement(), 1);
        }

        public void RemoveAllItemsAtRandomSlot()
        {
            var slotIndex = _inventoryData
                .ActualInventory()
                .Where(x => !x.Value.IsLocked)
                .Select(x => x.Key);

            if (!slotIndex.Any())
            {
                Debug.LogError("Инвентарь пуст");
                return;
            }

            _inventoryData.RemoveItemAtIndex(slotIndex.RandomElement());
        }
    }
}