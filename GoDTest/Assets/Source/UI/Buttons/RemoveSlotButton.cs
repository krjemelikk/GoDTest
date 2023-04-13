using Source.Infrastructure.Services.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.UI.Buttons
{
    public class RemoveSlotButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IInventoryService _inventoryService;

        private void Start()
        {
            _button.onClick.AddListener(RemoveRandomSlot);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        [Inject]
        private void Construct(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        private void RemoveRandomSlot()
        {
            _inventoryService.RemoveAllItemsAtRandomSlot();
        }
    }
}