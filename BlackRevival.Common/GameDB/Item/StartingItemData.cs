using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Item;

public class StartingItemData
{
    public string GetTypeName()
    {
        ItemType itemType = this.itemType;
        if (itemType == ItemType.WEAPON)
        {
            return this.weaponType.GetName();
        }
        return this.itemType.GetItemTypeName();
    }
    

    public bool IsExistsItem(int itemCode)
    {
        return this.changedItemSetList.Exists((ChangedItemSet x) => x.itemId == itemCode);
    }

    [JsonPropertyName("mtp")]
    public MapType mapType;

    [JsonPropertyName("itp")]
    public ItemType itemType;

    [JsonPropertyName("wtp")]
    public AcE_WEAPON_TYPE weaponType;

    [JsonPropertyName("iil")]
    public List<ChangedItemSet> changedItemSetList;

    [JsonPropertyName("did")] public int defaultId { get; set; }
}