using System;
using Newtonsoft.Json;
using Source.Enums;
using Source.Infrastructure.Services.StaticData;
using Source.StaticData;

namespace Source.Data.Converters
{
    public class ItemDataConverter : JsonConverter<ItemData>
    {
        private readonly IStaticDataService _staticDataService;

        public ItemDataConverter(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public override void WriteJson(JsonWriter writer, ItemData value, JsonSerializer serializer)
        {
            var itemData = value;

            if (itemData != null)
                serializer.Serialize(writer, itemData.ItemId);

            else
                writer.WriteNull();
        }


        public override ItemData ReadJson(JsonReader reader, Type objectType, ItemData existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var itemId = serializer.Deserialize<ItemTypeId>(reader);
            var itemData = _staticDataService.ForItem(itemId);

            return itemData;
        }
    }
}