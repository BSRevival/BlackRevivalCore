using System.Text.Json.Serialization;
using BlackRevival.Common.GameDB.Field;

namespace BlackRevival.Common.GameDB.Item;

public class ItemCombinationData
{
    public bool IsRandomMaterialItem(MapType mapType)
    {
        PlacedItemData placedItemData;
        PlacedItemData placedItemData2;
        if (!GameDB.FieldTypeDB.Instance.TryFindPlacedItemData(mapType, this.addend, out placedItemData) || !GameDB.FieldTypeDB.Instance.TryFindPlacedItemData(mapType, this.augend, out placedItemData2))
        {
            return false;
        }
        List<PlacedItemData.Entry> entries = placedItemData.entries;
        if (entries == null || entries.Count > 0)
        {
            List<PlacedItemData.Entry> entries2 = placedItemData2.entries;
            return entries2 != null && entries2.Count <= 0;
        }
        return true;
    }

    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("agd")]
    public int augend { get; set; }

    [JsonPropertyName("add")]
    public int addend { get; set; }

    [JsonPropertyName("rst")]
    public int result { get; set; }

    [JsonPropertyName("mtp")]
    public List<MapType> mapType { get; set; }
}