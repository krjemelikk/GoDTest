using Source.Enums;
using Source.Infrastructure.Services.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.UI.Buttons
{
    public class AddAmmoButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IInventoryService _inventoryService;

        private void Start()
        {
            _button.onClick.AddListener(AddAmmo);
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

        private void AddAmmo()
        {
            _inventoryService.AddItemStack(ItemTypeId.Ammo_Pistol);
            _inventoryService.AddItemStack(ItemTypeId.Ammo_AssaultRifle);
        }
    }
}