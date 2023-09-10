﻿using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Character = BlackRevival.Common.Model.Character;
using QuestProgress = BlackRevival.Common.Model.QuestProgress;

namespace BlackRevival.APIServer.Controllers;

public class LobbyController : Controller
{
    private readonly ILogger<LobbyController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;
    public LobbyController(ILogger<LobbyController> logger, AppDbContext context )
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }
    [HttpGet("/api/lobby", Name = "GetLobby")]
    public async Task<IActionResult> GetLobby()
    {
        var session = (APISession)HttpContext.Items["Session"];
        if (session == null)
        {
            return Json(new WebResponseHeader
            {
                Cod = 401,
                Msg = "Session Does not exist",
                Rst = null,
                Eac = 0
            });
        }
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == session.Session.userNum);
        var lobbyInitResult = new LobbyInitResult
        {
            activatedPotentialSkillId = 6001,
            expiredPotentialSkillId = 0,
            activeCharacter = _helper.GetActiveCharacterGameModel(session.Session.userNum).Result,
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
            existBanMode = true,
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
            ownSkins = new List<CharacterSkin>(),
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
            isAdmin = user.IsAdmin,
            isDefaultPerk = true,
            dormantAccount = false,
            dormantAccountDays = 0,
            rankPoint = 0,
            upgradeLeagueInfo = null,
            pickUpEvents = new List<PickUpApi.PickUpEvent>(),
            userPickUpEvents = new List<PickUpApi.UserPickUpEvent>(),
            questMaxProgress = 0,
            questProgress = 0,
            isSpecialQuest = true,
            iapDisable = true
        };
        
        var ownedSkins = _helper.GetOwnedCharSkins(session.Session.userNum).Result;
        foreach (var ownSkin in ownedSkins)
        {
            lobbyInitResult.ownSkins.Add(ownSkin);
        }


        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = lobbyInitResult,
            Eac = 0
        });
    }
}