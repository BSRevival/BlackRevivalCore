using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.AvatarBonus;


public class AvatarBonusData
{
    [JsonPropertyName("pid")]
    public string productId { get; set; }

    [JsonPropertyName("avt")]
    public string avatarType { get; set; }

    [JsonPropertyName("bgl")]
    private Dictionary<AvatarBonusData.BonusType, List<Goods>> bonusGoods { get; set; }

    public List<Goods> GetBonusGoods(AvatarBonusData.BonusType bonusType)
    {
        List<Goods> list = new List<Goods>();
        if (this.bonusGoods.ContainsKey(bonusType))
        {
            list.AddRange(this.bonusGoods[bonusType]);
        }
        return list;
    }

    public enum BonusType
    {
        None,
        BATTLE_ASSET_BONUS,
        DAILY_SUPPLY_BONUS,
        DNA_PRODUCTION
    }
}