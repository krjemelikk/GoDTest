using Source.Enums;
using Source.Infrastructure.Services.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.UI.Buttons
{
    public class AddRandomItemsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IInventoryService _inventoryService;

        private void Start()
        {
            _button.onClick.AddListener(AddRandomItems);
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

        private void AddRandomItems()
        {
            _inventoryService.AddRandomItem(ItemTypeId.Gun_Pistol, ItemTypeId.Gun_AssaultRifle);
            _inventoryService.AddRandomItem(ItemTypeId.Head_Cap, ItemTypeId.Head_Helmet);
            _inventoryService.AddRandomItem(ItemTypeId.Torso_Jacket, ItemTypeId.Torso_BulletproofVest);
        }
    }
}