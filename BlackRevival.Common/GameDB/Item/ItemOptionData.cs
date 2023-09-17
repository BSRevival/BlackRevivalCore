using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.GameDB.Item;

public class ItemOptionData
{
    public string GetColor(float point)
    {
        return this.itemOptionColor.GetColor(point);
    }

    public string GetPropertyName()
    {
        return this.itemBaseAbility.GetPropertyName();
    }

    [JsonPropertyName("iba")]
    public ItemBaseAbility itemBaseAbility;

    [JsonPropertyName("ioc")]
    public ItemOptionColor itemOptionColor;
}