using System;
using System.Collections.Generic;
using System.Linq;
using Source.UI.Elements;
using UnityEngine;

namespace Source.UI
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] public Transform Content;
        [SerializeField] private DraggableItem _draggableItem;
        private int _draggableItemIndex = -1;

        private List<UIInventoryItem> _items;

        private void OnDestroy()
        {
            foreach (var item in _items)
                RemoveHandles(item);
        }

        public event Action<int> StartDragging;
        public event Action<int, int> SwapItems;

        public void Initialize()
        {
            _items = GetComponentsInChildren<UIInventoryItem>().ToList();

            foreach (var item in _items)
                AddHandles(item);
        }

        public void UpdateItemData(int itemIndex, Sprite itemIcon, int count, bool isLocked)
        {
            if (_items.Count > itemIndex)
                _items[itemIndex].SetData(itemIcon, count, isLocked);
        }

        public void ResetAllItemData()
        {
            foreach (var item in _items)
                item.ResetData();
        }

        public void SetDataToDraggableItem(Sprite sprite, int count)
        {
            _draggableItem.SetData(sprite, count);
            _draggableItem.SetActive(true);
        }

        private void HandleItemBeginDrag(UIInventoryItem item)
        {
            var index = _items.IndexOf(item);
            if (index == -1 || item.IsLocked || item.IsEmpty)
                return;

            _draggableItemIndex = index;
            StartDragging?.Invoke(index);
        }

        private void HandleItemDroppedOn(UIInventoryItem item)
        {
            var index = _items.IndexOf(item);
            if (item.IsLocked || index == -1 || _draggableItemIndex == -1)
                return;

            SwapItems?.Invoke(_draggableItemIndex, index);
        }

        private void HandleItemEndDrag(UIInventoryItem item)
        {
            ResetDraggableItem();
        }

        private void ResetDraggableItem()
        {
            _draggableItem.SetActive(false);
            _draggableItemIndex = -1;
        }

        private void AddHandles(UIInventoryItem item)
        {
            item.OnItemDroppedOn += HandleItemDroppedOn;
            item.OnItemBeginDrag += HandleItemBeginDrag;
            item.OnItemEndDrag += HandleItemEndDrag;
        }

        private void RemoveHandles(UIInventoryItem item)
        {
            item.OnItemDroppedOn -= HandleItemDroppedOn;
            item.OnItemBeginDrag -= HandleItemBeginDrag;
            item.OnItemEndDrag -= HandleItemEndDrag;
        }
    }
}