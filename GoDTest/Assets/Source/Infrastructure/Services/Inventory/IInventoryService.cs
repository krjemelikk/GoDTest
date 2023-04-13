using Source.Enums;

namespace Source.Infrastructure.Services.Inventory
{
    public interface IInventoryService
    {
        void AddItemStack(ItemTypeId itemId);
        void RemoveAllItemsAtRandomSlot();
        void UnlockSlot();
        void RemoveOneRandomAmmo();
        void AddRandomItem(params ItemTypeId[] itemIds);
    }
}