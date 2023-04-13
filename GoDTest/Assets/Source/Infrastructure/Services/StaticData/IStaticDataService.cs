using Source.Enums;
using Source.StaticData;

namespace Source.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        InventoryInitialData ForInventory();
        ItemData ForItem(ItemTypeId itemId);
    }
}