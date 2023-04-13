using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Source.UI.Elements
{
    public class UIInventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler,
        IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image ItemImage;
        [SerializeField] private TMP_Text Count;
        [SerializeField] private Image TextBackground;

        public bool IsEmpty { get; private set; }
        public bool IsLocked { get; private set; }

        private void Awake()
        {
            ResetData();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }


        public event Action<UIInventoryItem>
            OnItemDroppedOn,
            OnItemBeginDrag,
            OnItemEndDrag;

        public void SetData(Sprite sprite, int count, bool isLocked)
        {
            ItemImage.sprite = sprite;
            ItemImage.gameObject.SetActive(true);
            IsEmpty = false;
            IsLocked = isLocked;

            if (count <= 1)
            {
                TextBackground.gameObject.SetActive(false);
            }

            else
            {
                TextBackground.gameObject.SetActive(true);
                Count.text = count.ToString();
            }
        }

        public void ResetData()
        {
            ItemImage.sprite = null;
            IsEmpty = true;
            IsLocked = false;
            ItemImage.gameObject.SetActive(false);
            TextBackground.gameObject.SetActive(false);
        }
    }
}