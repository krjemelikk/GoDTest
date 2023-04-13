using Source.Enums;
using Source.StaticData;

namespace Source.Infrastructure.Factory
{
    public interface IItemFactory
    {
        ItemData CreateItem(ItemTypeId itemId);
    }
}