using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class LobbyInitResult
{
    public int activatedPotentialSkillId{ get; set; }

    public int expiredPotentialSkillId{ get; set; }

    public Character activeCharacter{ get; set; }

    public int carnivorousTenPlay{ get; set; }

    public int herivCount{ get; set; }

    public bool newDiaryCheck{ get; set; }

    public List<QuestProgress> questProgressList{ get; set; }

    public bool newPostArrived{ get; set; }

    public List<InvenGoods> invenGoodsList{ get; set; }

    public bool weeklyQuestClear{ get; set; }

    public bool dailyQuestClear{ get; set; }

    public bool tutorialQuestClear{ get; set; }

    public bool dailyEventQuestClear{ get; set; }

    public bool aPassQuestClear{ get; set; }

    public bool existBanCharacter{ get; set; }

    public bool existBanMode{ get; set; }

    public AglaiaPassProgress activeAglaiaPass{ get; set; }

    public List<PurchaseHistory> todaysPurchaseHistory{ get; set; }

    public List<AttendanceEventRecord> attendanceEventRecords{ get; set; }

    public List<NavPresetGroup> navPresetGroups{ get; set; }

    public List<QuestProgress> progressList{ get; set; }

    public List<CharacterSkin> ownSkins{ get; set; }

    public bool isExistExpiredReward{ get; set; }

    public List<Promotion> userPromotions{ get; set; }

    public List<BonusRewardEvent> bonusRewardEvents{ get; set; }

    public bool voteNow{ get; set; }

    public List<LabGoods> labList{ get; set; }

    public bool isAdmin{ get; set; }

    public bool isDefaultPerk{ get; set; }

    public bool dormantAccount{ get; set; }

    public int dormantAccountDays{ get; set; }

    public int rankPoint{ get; set; }

    public UpgradeLeagueInfo upgradeLeagueInfo{ get; set; }

    public List<PickUpApi.PickUpEvent> pickUpEvents{ get; set; }

    public List<PickUpApi.UserPickUpEvent> userPickUpEvents{ get; set; }

    public int questMaxProgress{ get; set; }

    public int questProgress{ get; set; }

    public bool isSpecialQuest{ get; set; }

    public bool iapDisable{ get; set; }
}