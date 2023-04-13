using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/InventoryItem/LockedItem", fileName = "LockedItem")]
    public class LockedItemData : ItemData
    {
        public int UnlockPrice;
    }
}