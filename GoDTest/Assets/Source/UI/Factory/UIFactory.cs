using Source.Data.Inventory;
using Source.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Source.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IInstantiator _instantiator;

        private Transform _uiRoot;

        public UIFactory(IInstantiator instantiator, IAssetProvider assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }

        public void CreateUIRoot()
        {
            var prefab = _assets.Load<GameObject>(AssetAddress.UIRoot);
            var uiRoot = _instantiator.InstantiatePrefab(prefab);

            _uiRoot = uiRoot.transform;
        }

        public UIInventory CreateInventory(InventoryData inventoryData)
        {
            var inventoryPrefab = _assets.Load<GameObject>(AssetAddress.Inventory);
            var inventoryItemPrefab = _assets.Load<GameObject>(AssetAddress.InventoryItem);

            var inventory = _instantiator.InstantiatePrefab(inventoryPrefab, _uiRoot);
            var uiInventory = inventory.GetComponent<UIInventory>();

            for (var i = 0; i < inventoryData.Size; i++)
                _instantiator.InstantiatePrefab(inventoryItemPrefab, uiInventory.Content);

            return uiInventory;
        }

        public void CreateButtons()
        {
            var buttonsPrefab = _assets.Load<GameObject>(AssetAddress.Buttons);
            _instantiator.InstantiatePrefab(buttonsPrefab, _uiRoot);
        }
    }
}