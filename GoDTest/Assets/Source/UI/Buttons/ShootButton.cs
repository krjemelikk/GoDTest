using Source.Infrastructure.Services.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.UI.Buttons
{
    public class ShootButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IInventoryService _inventoryService;

        private void Start()
        {
            _button.onClick.AddListener(RemoveAmmo);
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

        private void RemoveAmmo()
        {
            _inventoryService.RemoveOneRandomAmmo();
        }
    }
}