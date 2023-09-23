using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class IngameController : Controller
{
    private readonly ILogger<IngameController> _logger;
    
    public IngameController(ILogger<IngameController> logger)
    {
        _logger = logger;
    }
    
    //Setup GameplayCheck
    [HttpGet("/api/gameplay/check/{userid}/{game}", Name = "GameplayCheck")]
    public IActionResult GameplayCheck(int userId, int game)
    {
        var resp = new IngameApi.IngameEnterableResult
        {
            isPossible = true
        };
        return Json(new WebResponseHeader
        {
 
            Cod = 200,
            Msg = "SUCCESS",
            Rst = resp,
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/matching/team")]
    public IActionResult postMatchingTeamMode()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/matching/normal")]
    public IActionResult postMatchingNormal()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/matching/rank")]
    public IActionResult postMatchingRanked()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/matching/matchingInfo/{0}")]
    public IActionResult postMatchingInfo()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/create/{0}")]
    public IActionResult postMatchCreate()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/ingame/join/{0}/{1}")]
    public IActionResult postMatchJoin()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
}