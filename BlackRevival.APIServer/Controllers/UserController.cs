﻿using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/api/users/{userNum}/potentialSkillList", Name = "GetPotentialSkillList")]
    public IActionResult GetPotentialSkillList(int userNum)
    {
        var result = new PotentialSkillListResult
        {
            perkList = new List<PerkApi.PerkPreset>
            {
                new PerkApi.PerkPreset { isDefault = true, num = 2712807, userNum = 7562069, name = "DEFAULT", category = 10001, baseFirst = 10101, baseSecond = 10201, activated = true }
            },
            list = new List<UserPotentialSkill>
            {
                new UserPotentialSkill { remainTime = 0, freeItem = true, getBattleMode = 100, skillId = 6001 }
            }
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    
    [HttpPost("/api/users/{userNum}", Name = "GetUser")]
    public IActionResult GetUser(int userNum)
    {
        var user = new Common.Model.User
        {
            userNum = 7562069,
            receivePushMsg = true,
            newPostArrived = true,
            termsAgree = true,
            nickname = "ReplaceNameHere",
            tutorialProgress = 0,
            bgm = true,
            soundEffect = true,
            lastword = "How can I die here...",
            watchword = "Come at me",
            activeCharacterNum = 10136633,
            appLanguageCode = "en",
            leaguePoint = 0,
            adViewCount = 10,
            maxAdViewCount = 10,
            activatedPotentialSkillId = 0,
            researcherExp = 0,
            researcherTitleCode = 0,
            matchingCardCode = 0,
            lto = false,
            ltt = false,
            lte = false,
            ltf = false,
            ltv = false,
            ltr = false,
            sigc = 0,
            sigg = 0,
            rtn = "NONE",
            aps = 6001,
            league = League.MOUSE5,
            // initialize other properties as needed
            // initialize UserAsset properties
            gold = 10000000,
            gem = 10000000,
            bearPoint = 1000000,
            credit = 0,
            mileage = 1000000,
            experimentMemory = 0,
            tournamentPoint = 0,
            tournamentTicket = 0,
            voteTicket = 0,
            voteStamp = 0,
            labyrinthPoint = 0,
            agliaScore = 0
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = user,
            Eac = 0
        });
    }
    
    [HttpGet("/api/users/remainFreeBpRouletteTime", Name = "GetNextBPRouletteTime")]
    public IActionResult GetNextBPRouletteTime()
    {
        //This just sets it so that its always active
        var result = new Dictionary<string, int>() { { "remainTime", 0 } };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    [HttpGet("/api/users/freeBpRoulette", Name = "FreeBPRoulette")]
    public IActionResult FreeBPRoulette()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/users/postLatency", Name = "PostLatency")]
    public IActionResult PostLatency()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
}