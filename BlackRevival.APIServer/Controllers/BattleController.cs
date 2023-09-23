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
            /*unm = user.UserNum,
            bmd = 0,
            chc = 0,
            cst = 0,
            sea	= 10,
            grp	= 0,
            pdtm = 907,
            pcnt = 1,
            wcnt = 0,
            lvl = 12,
            mrs = 128,
            phdam = 1103,
            mhdam = 795,
            pkcnt = 1,
            mkcnt = 5,
            ascnt = 0,
            dcnt = 0,
            umc = 0,
            upc = 0,
            scnt = 270,
            sfcnt = 69,
            fecnt = 39,
            fmcnt = 7,
            aecnt = 30,
            amcnt = 12,
            mec = 10,
            mfc = 9,
            metc = 8,
            ewc = 0,
            ewv = 0,
            asp = 18,
            asc = 0,
            asf = 3,
            tphdam = 1103,
            tmhdam = 795,
            tpkcnt = 1,
            tmkcnt = 5,
            tdcnt = 0,
            tascnt = 0,
            tscnt = 270,
            tsfcnt = 69,
            tfecnt = 39,
            tfmcnt = 7,
            taecnt = 30,
            tamcnt = 12,
            tmec = 10,
            tmfc = 9,
            tmetc = 8,
            tewc = 0,
            tewv = 0,
            tasp = 18,
            tasc = 0,
            tasf = 3,
            wrt = 0,
            grd = "A"*/
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
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("api/pingServerList")]
    public async Task<IActionResult> getPingServerList()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("api/battle/record/all/{0}/{1}/{2}")]
    public async Task<IActionResult> getAllBattleRecord()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
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