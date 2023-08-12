using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class LobbyController : Controller
{
    private readonly ILogger<LobbyController> _logger;

    public LobbyController(ILogger<LobbyController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/api/lobby", Name = "GetLobby")]
    public IActionResult GetLobby()
    {
        var lobbyInitResult = new LobbyInitResult
        {
            activatedPotentialSkillId = 6001,
            expiredPotentialSkillId = 0,
            activeCharacter = new Character
            {
                characterNum = 10136633,
                userNum = 7562069,
                userNickname = "",
                characterClass = 4,
                characterGrade = (CharacterGrade)1,
                activeCharacterSkinType = 401,
                activeLive2D = false,
                enhanceExp = 0,
                characterPurchaseType = (CharacterPurchaseType)2,
                rankPlayCount = 0,
                rankWinCount = 0,
                normalPlayCount = 0,
                normalWinCount = 0,
                teamNumber = 0,
                potentialSkillId = 0,
                pmn = 0,
                pfr = 0,
                psd = 0,
                host = false,
                characterStatus = (CharacterStatus)1,
                toNormalRemainSeconds = 0
            },
            carnivorousTenPlay = 0,
            herivCount = 0,
            newDiaryCheck = false,
            questProgressList = new List<QuestProgress>(),
            newPostArrived = true,
            invenGoodsList = new List<InvenGoods>
            {
                new InvenGoods
                {
                    c = "12-LABYRINTH_TICKET",
                    a = 3,
                    num = 3517694,
                    userNum = 7562069,
                    isActivated = false,
                    activated = false
                }
            },
            weeklyQuestClear = true,
            dailyQuestClear = false,
            tutorialQuestClear = false,
            dailyEventQuestClear = false,
            aPassQuestClear = false,
            existBanCharacter = false,
            existBanMode = false,
            activeAglaiaPass = null,
            todaysPurchaseHistory = new List<PurchaseHistory>(),
            attendanceEventRecords = new List<AttendanceEventRecord>
            {
                new AttendanceEventRecord
                {
                    eventId = 1,
                    attendanceCount = 1,
                    isActivatedNow = false,
                    startDtm = 1665680826000,
                    lastAttendDtm = 1665680826000,
                    expireDtm = 1667746799000,
                    rewarded = false
                }
            },
            navPresetGroups = new List<NavPresetGroup>
            {
                new NavPresetGroup
                {
                    groupId = 270170,
                    userNum = 7562069,
                    groupNum = 0,
                    groupName = "",
                    presets = new List<NavPreset>()
                }
            },
            progressList = new List<QuestProgress>
            {
                new QuestProgress
                {
                    questProgressId = 42709415,
                    questId = 22001,
                    renewalType = (QuestRenewalType)101,
                    progress = 0,
                    cleared = false,
                    rewarded = false,
                    expireDtm = 1665759600000
                },
                // Add more QuestProgress items as needed
            },
            ownSkins = new List<CharacterSkin>
            {
                new CharacterSkin
                {
                    userNum = 7562069,
                    characterClass = 1,
                    characterSkinType = 101,
                    owned = true,
                    activeLive2D = false,
                    skinEnableType = (SkinEnableType)1
                },
                // Add more CharacterSkin items as needed
            },
            isExistExpiredReward = false,
            userPromotions = new List<Promotion>(),
            bonusRewardEvents = new List<BonusRewardEvent>(),
            voteNow = false,
            labList = new List<LabGoods>
            {
                new LabGoods
                {
                    userNum = 7562069,
                    labNum = 6803285,
                    labType = (LabType)1,
                    bgSubType = "BASIC",
                    isActivated = true,
                    components = "",
                    invenGoodsList = new List<long>()
                },
                // Add more LabGoods items as needed
            },
            isAdmin = true,
            isDefaultPerk = true,
            dormantAccount = false,
            dormantAccountDays = 0,
            rankPoint = 0,
            upgradeLeagueInfo = null,
            pickUpEvents = new List<PickUpApi.PickUpEvent>(),
            userPickUpEvents = new List<PickUpApi.UserPickUpEvent>(),
            questMaxProgress = 0,
            questProgress = 0,
            isSpecialQuest = false,
            iapDisable = true
        };

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = lobbyInitResult,
            Eac = 0
        });
    }
}