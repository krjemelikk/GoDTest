using System;
using Source.StaticData;

namespace Source.Data.Inventory
{
    [Serializable]
    public struct InventorySlot
    {
        public int Count;
        public ItemData ItemData;
        public bool IsLocked;

        public InventorySlot(ItemData itemData, int count) : this()
        {
            Count = count;
            ItemData = itemData;
        }

        public InventorySlot(ItemData itemData, int count, bool locked) : this()
        {
            ItemData = itemData;
            Count = count;
            IsLocked = locked;
        }

        public bool IsEmpty => ItemData == null;

        public InventorySlot ChangeCount(int newCount)
        {
            return new(ItemData, newCount);
        }

        public static InventorySlot EmptySlot()
        {
            return new(null, 0, false);
        }

        public static InventorySlot LockedSlot(ItemData lockedItemData)
        {
            return new(lockedItemData, 0, true);
        }
    }
}