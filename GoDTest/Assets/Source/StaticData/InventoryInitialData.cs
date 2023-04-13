using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/InventoryData", fileName = "InventoryData")]
    public class InventoryInitialData : ScriptableObject
    {
        public int InitialMoney;
        public int OpenedSlots;
        public int LockedSlots;
    }
}