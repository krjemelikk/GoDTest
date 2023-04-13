using Source.Enums;
using UnityEngine;

namespace Source.StaticData
{
    public abstract class ItemData : ScriptableObject
    {
        public ItemTypeId ItemId;
        public Sprite Sprite;
        public bool IsStackable;
        public int MaxStackSize = 1;
        public float Weight;
    }
}