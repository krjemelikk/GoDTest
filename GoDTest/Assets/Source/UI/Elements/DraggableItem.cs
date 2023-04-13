using Source.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Source.UI.Elements
{
    public class DraggableItem : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _item;

        private Canvas _canvas;
        private IInputService _inputService;

        private void Update()
        {
            FollowTheMouse();
        }

        [Inject]
        private void Construct(IInputService inputService)
        {
            _canvas = transform.root.GetComponent<Canvas>();
            _inputService = inputService;
            SetActive(false);
        }

        public void SetData(Sprite sprite, int count)
        {
            _item.SetData(sprite, count, false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        private void FollowTheMouse()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform) _canvas.transform,
                _inputService.MousePosition,
                _canvas.worldCamera,
                out var position);

            transform.position = _canvas.transform.TransformPoint(position);
        }
    }
}