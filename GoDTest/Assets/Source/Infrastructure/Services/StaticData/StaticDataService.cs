using System.Collections.Generic;
using Source.Enums;
using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly Dictionary<ItemTypeId, ItemData> _itemData = new();

        public void Load()
        {
            LoadAmmo();
            LoadGun();
            LoadHead();
            LoadTorso();
            LoadLocked();
        }

        public InventoryInitialData ForInventory()
        {
            return Resources.Load<InventoryInitialData>(StaticDataPath.Inventory);
        }

        public ItemData ForItem(ItemTypeId itemId)
        {
            return _itemData.TryGetValue(itemId, out var itemData) ? itemData : null;
        }

        private void LoadAmmo()
        {
            var data = Resources
                .LoadAll<AmmoData>(StaticDataPath.Ammo);

            foreach (var ammoData in data)
                _itemData.Add(ammoData.ItemId, ammoData);
        }

        private void LoadGun()
        {
            var data = Resources.LoadAll<GunData>(StaticDataPath.Gun);

            foreach (var gunData in data)
                _itemData.Add(gunData.ItemId, gunData);
        }

        private void LoadHead()
        {
            var data = Resources.LoadAll<HeadData>(StaticDataPath.Head);

            foreach (var headData in data)
                _itemData.Add(headData.ItemId, headData);
        }

        private void LoadTorso()
        {
            var data = Resources.LoadAll<TorsoData>(StaticDataPath.Torso);

            foreach (var torsoData in data)
                _itemData.Add(torsoData.ItemId, torsoData);
        }

        private void LoadLocked()
        {
            var data = Resources.Load<LockedItemData>(StaticDataPath.LockedItem);
            _itemData.Add(data.ItemId, data);
        }
    }
}