using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class TournamentController : Controller
{
    [HttpGet("/api/tournament/reset")]
    public IActionResult getTournamentReset()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/summary")]
    public IActionResult getTournamentSummary()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/rank/summary")]
    public IActionResult getTournamentRankSummary()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/rank/accrue")]
    public IActionResult getTournamentRankAccrue()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/rank/{0}/{1}/{2}")]
    public IActionResult getTournamentRankParams()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/rank/accrue/{0}/{1}/{2}")]
    public IActionResult getTournamentRankAccrueParams()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/shop")]
    public IActionResult getTournamentShop()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpGet("/api/tournament/shop/purchase/{0}")]
    public IActionResult getTournamentShopPurchase()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpPost("/api/tournament/lastUpdate")]
    public IActionResult postTournamentLastUpdate()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
    
    [HttpPost("/api/tournament/enter")]
    public IActionResult postTournamentEnter()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new { },
            Eac = 0
        });
    }
}