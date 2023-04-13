using Source.Enums;
using Source.Infrastructure.Services.StaticData;
using Source.StaticData;

namespace Source.Infrastructure.Factory
{
    public class ItemFactory : IItemFactory
    {
        private readonly IStaticDataService _staticDataService;

        public ItemFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public ItemData CreateItem(ItemTypeId itemId)
        {
            return _staticDataService.ForItem(itemId);
        }
    }
}