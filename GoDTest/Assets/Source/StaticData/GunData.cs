using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/InventoryItem/Gun", fileName = "Gun")]
    public class GunData : ItemData
    {
        public AmmoData AmmoId;
        public int Damage;
    }
}