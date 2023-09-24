using System.Text.Json;
using System.Text.Json.Serialization;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Model.AcE;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Character = BlackRevival.Common.Model.User;

namespace BlackRevival.APIServer.Controllers;

public class BattleController: Controller
{
    private readonly ILogger<BattleController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;
    
    public BattleController(ILogger<BattleController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }
    
    [HttpGet("/api/battle/record/detailAll/{0}/{1}")]
    public async Task<IActionResult> getDetailAll(long userNum)
    {
        var session = (APISession)HttpContext.Items["Session"];
        var user = _helper.GetUserByNum(userNum).Result;

        var recordDetailList = new Common.Model.User
        {
            /*
            unm = user.UserNum,
            bmd = 0, battleMode
            chc = 0, characterClass
            cst = 0, characterSkinType
            sea	= 10, season
            grp	= 0, gainRankPoint
            pdtm = 907, playTime
            pcnt = 1, playCount
            wcnt = 0, winCount
            lvl = 12, level
            mrs = 128, masteryResult
            phdam = 1103, playerHitDamage
            mhdam = 795, monsterHitDamage
            pkcnt = 1, playerKillCount
            mkcnt = 5, monsterKillCount
            ascnt = 0, assistCount
            dcnt = 0, deadCount
            umc = 0,
            upc = 0,
            scnt = 270, searchCount
            sfcnt = 69, shiftFieldCount
            fecnt = 39, findEnemyCount
            fmcnt = 7, findMonsterCount
            aecnt = 30, attackEnemyCount
            amcnt = 12, attackMonsterCount
            mec = 10,
            mfc = 9,
            metc = 8,
            ewc = 0,
            ewv = 0,
            asp = 18, activeSkillPassive
            asc = 0, activeSkillCombat
            asf = 3, activeSkillField
            tphdam = 1103, topPlayerHitDamage
            tmhdam = 795, topMonsterHitDamage
            tpkcnt = 1, topPlayerKillCount
            tmkcnt = 5, topMonsterKillCount
            tdcnt = 0, topDeathCount
            tascnt = 0, topAssistCount
            tscnt = 270, topSearchCount
            tsfcnt = 69, topShiftFieldCount
            tfecnt = 39, topFindEnemyCount
            tfmcnt = 7, topFindMonsterCount
            taecnt = 30, topAttackEnemyCount
            tamcnt = 12, topAttackMonsterCount
            tmec = 10,
            tmfc = 9,
            tmetc = 8,
            tewc = 0,
            tewv = 0,
            tasp = 18, topActiveSkillPassive
            tasc = 0, topActiveSkillCombat
            tasf = 3, topActiveSkillField
            wrt = 0,
            grd = "A" getMasteryRank*/
        };
            
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/battle/record/all/{0}/{1}/{2}")]
    public async Task<IActionResult> getRecordAll()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/battle/record/character/{0}/{1}/{2}/{3}")]
    public async Task<IActionResult> getRecordCharacter()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }

    [HttpGet("/api/battle/running/request")]
    public async Task<IActionResult> getRunningBattleRequest()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/battle/result")]
    public async Task<IActionResult> postBattleResult()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPut("/api/battle/doubtHacking/{0}/{1}")]
    public async Task<IActionResult> putDoubtHacking()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }

    [HttpGet("/api/battle/decisionStartGame")]
    public async Task<IActionResult> getDecisionStartGame()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    
    [HttpGet("api/battle/waitingReward/{0}/{1}")]
    public async Task<IActionResult> getBattleWaitingReward()
    {   
        //Here we pay out gold to users who are queuing for a ranked match after x amount of time
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
}