using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.GameDB;

namespace BlackRevival.Common.GameDB.Expedition;

public class ExpeditionCardData
{
    public int GetCost(int level)
    {
        if (this.costPerLevel == null || this.costPerLevel.Count == 0)
        {
            return 1;
        }
        if (!this.costPerLevel.ContainsKey(level))
        {
            return 1;
        }
        return this.costPerLevel[level];
    }

    public bool IsUserTarget()
    {
        ExpeditionSkillTargetType expeditionSkillTargetType = (ExpeditionSkillTargetType)this.targetType;
        return expeditionSkillTargetType == ExpeditionSkillTargetType.ALL || expeditionSkillTargetType == ExpeditionSkillTargetType.MYSELF || expeditionSkillTargetType == ExpeditionSkillTargetType.OUR || expeditionSkillTargetType == ExpeditionSkillTargetType.OUR_TEAM;
    }

    public bool IsEnemyTarget()
    {
        ExpeditionSkillTargetType expeditionSkillTargetType = (ExpeditionSkillTargetType)this.targetType;
        return expeditionSkillTargetType == ExpeditionSkillTargetType.ALL || expeditionSkillTargetType == ExpeditionSkillTargetType.ENEMY || expeditionSkillTargetType == ExpeditionSkillTargetType.ENEMY_RANDOM || expeditionSkillTargetType == ExpeditionSkillTargetType.ENEMY_TEAM;
    }

    public AcE_CARD_TYPE GetCardType()
    {
        return (AcE_CARD_TYPE)this.cardType;
    }

    public bool IsSkillCard()
    {
        return this.GetCardType() == AcE_CARD_TYPE.NORMAL || this.GetCardType() == AcE_CARD_TYPE.SKILL_COMBAT || this.GetCardType() == AcE_CARD_TYPE.SKILL_FIELD || this.GetCardType() == AcE_CARD_TYPE.SKILL_SPECIAL_HAVE_EFFECT;
    }

    public bool IsFoodCard()
    {
        return !this.IsSkillCard();
    }

    public string GetCardTypeName()
    {
        AcE_CARD_TYPE acE_CARD_TYPE = (AcE_CARD_TYPE)this.cardType;
        if (acE_CARD_TYPE == AcE_CARD_TYPE.NORMAL)
        {
            return LocalizationDB.Instance.Dynamic("PVE_BATTLE_CARD_NORMAL_LABEL_01");
        }
        switch (acE_CARD_TYPE)
        {
            case AcE_CARD_TYPE.SKILL_PASSIVE:
                return LocalizationDB.Instance.Dynamic("패시브");
            case AcE_CARD_TYPE.SKILL_COMBAT:
            case AcE_CARD_TYPE.SKILL_SPECIAL_HAVE_EFFECT:
                return LocalizationDB.Instance.Dynamic("PVE_BATTLE_CARD_COMBAT_LABEL_01");
            case AcE_CARD_TYPE.SKILL_FIELD:
                return LocalizationDB.Instance.Dynamic("필드");
            default:
                return string.Empty;
        }
    }

    [JsonPropertyName("cid")]
    public int cardId { get; set; }

    [JsonPropertyName("ett")]
    public int targetType { get; set; }

    [JsonPropertyName("ctp")]
    public int cardType { get; set; }

    [JsonPropertyName("csk")]
    public Dictionary<int, List<int>> skillForCardLevel { get; set; }

    [JsonPropertyName("cpl")]
    public Dictionary<int, int> costPerLevel { get; set; }

    [JsonPropertyName("sin")]
    public string skillIconName { get; set; }

}