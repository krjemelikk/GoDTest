using System;
using System.Collections.Generic;
using System.Linq;
using Source.Enums;
using Source.StaticData;
using UnityEngine;

namespace Source.Data.Inventory
{
    [Serializable]
    public class InventoryData
    {
        public int Money;
        public int Size;
        public List<InventorySlot> Items;

        public InventoryData(int money, int size, List<InventorySlot> _items)
        {
            Money = money;
            Size = size;
            Items = _items;
        }

        public float Weight => GetWeight();

        public event Action<Dictionary<int, InventorySlot>> DataChanged;


        public Dictionary<int, InventorySlot> ActualInventory()
        {
            Dictionary<int, InventorySlot> result = new();

            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].IsEmpty)
                    continue;

                result[i] = Items[i];
            }

            return result;
        }

        public void AddItem(ItemData inventoryItem, int count)
        {
            if (!inventoryItem.IsStackable)
            {
                while (count > 0 && !IsInventoryFull())
                    count -= AddItemToEmptySlot(inventoryItem, 1);
                OnDataChanged();
                return;
            }

            AddStackableItem(inventoryItem, count);
            OnDataChanged();
        }

        public void UnlockSlot()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!Items[i].IsLocked)
                    continue;

                Debug.Log(Items[i]);

                Items[i] = InventorySlot.EmptySlot();
                OnDataChanged();
                return;
            }
        }

        public InventorySlot GetItem(int itemIndex)
        {
            return Items[itemIndex];
        }

        public InventorySlot GetItem(ItemTypeId type)
        {
            return Items
                .FirstOrDefault(i =>
                    !i.IsEmpty && Equals(i.ItemData.ItemId, type));
        }

        public void SwapItems(int itemIndex1, int itemIndex2)
        {
            (Items[itemIndex1], Items[itemIndex2]) = (Items[itemIndex2], Items[itemIndex1]);
            OnDataChanged();
        }

        public void RemoveItem(ItemTypeId itemType, int count)
        {
            var itemForDelete = GetItem(itemType);

            if (itemForDelete.IsEmpty)
                return;

            RemoveItem(itemForDelete, count);
            OnDataChanged();
        }

        public void RemoveItem(InventorySlot slot, int count)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (count <= 0)
                    break;

                if (!Items[i].IsEmpty && !Items[i].IsLocked && Equals(Items[i].ItemData.ItemId, slot.ItemData.ItemId))
                    count = RemoveItemAtIndex(i, count);
            }

            OnDataChanged();
        }

        public void RemoveItemAtIndex(int index)
        {
            var item = GetItem(index);

            if (item.IsLocked)
                return;

            RemoveItemAtIndex(index, item.Count);
            OnDataChanged();
        }

        private bool IsInventoryFull()
        {
            return !Items.Any(x => x.IsEmpty);
        }

        private float GetWeight()
        {
            return Items
                .Where(item => !item.IsEmpty)
                .Sum(item => item.ItemData.Weight * item.Count);
        }


        private int AddItemToEmptySlot(ItemData itemData, int count)
        {
            var newItem = new InventorySlot(itemData, count);

            for (var i = 0; i < Items.Count; i++)
                if (Items[i].IsEmpty)
                {
                    Items[i] = newItem;
                    return count;
                }

            return 0;
        }

        private int RemoveItemAtIndex(int itemIndex, int count)
        {
            var reminder = Items[itemIndex].Count - count;

            if (reminder <= 0)
            {
                Items[itemIndex] = InventorySlot.EmptySlot();
                return -1 * reminder;
            }

            Items[itemIndex] = Items[itemIndex]
                .ChangeCount(reminder);

            return 0;
        }

        private int AddStackableItem(ItemData ItemData, int count)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].IsEmpty || Items[i].IsLocked)
                    continue;

                if (Equals(Items[i].ItemData.ItemId, ItemData.ItemId))
                {
                    var possibleCountToTake = Items[i].ItemData.MaxStackSize - Items[i].Count;

                    if (count > possibleCountToTake)
                    {
                        Items[i] = Items[i].ChangeCount(Items[i].ItemData.MaxStackSize);
                        count -= possibleCountToTake;
                    }

                    else
                    {
                        Items[i] = Items[i].ChangeCount(Items[i].Count + count);
                        return 0;
                    }
                }
            }

            while (count > 0 && !IsInventoryFull())
            {
                var newCount = Mathf.Clamp(count, 0, ItemData.MaxStackSize);
                count -= newCount;
                AddItemToEmptySlot(ItemData, newCount);
            }

            return count;
        }

        private void OnDataChanged()
        {
            DataChanged?.Invoke(ActualInventory());
        }
    }
}