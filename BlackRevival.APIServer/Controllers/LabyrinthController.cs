using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class LabyrinthController: Controller
{
    private readonly ILogger<LabyrinthController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public LabyrinthController(ILogger<LabyrinthController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }   
    
    //Refresh Labyrinth
    [HttpGet("/api/labyrinth/refresh/{uid}", Name = "RefreshLabyrinth")]
    public IActionResult RefreshLabyrinth(string uid)
    {
        
        var apiSession = (APISession)HttpContext.Items["Session"];
        if (apiSession == null)
        {
            return Json(new WebResponseHeader
            {
                Cod = 401,
                Msg = "Session Does not exist",
                Rst = null,
                Eac = 0
            });
        }
        
        var user = _helper.GetUserByNum(apiSession.Session.userNum).Result;
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = user,
            Eac = 0
        });
    }
    
    [HttpGet ("/api/labryinth/info/{0}")]
    public IActionResult getSignatureUpgrade()
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

    [HttpGet ("/api/labryinth/autoStart/{0}/{1}/{2}")]
    public IActionResult getLabyrinthAutoStart()
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

    [HttpGet ("/api/labryinth/deletePlayData/{0}")]
    public IActionResult getLabyrinthDeletePlayData()
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
    
    [HttpGet ("/api/labryinth/openAllArea/{0}/{1}")]
    public IActionResult getLabyrinthOpenAll()
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
    
    [HttpGet ("/api/labryinth/openArea/{0}/{1}/{2}")]
    public IActionResult getLabyrinthOpenArea()
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
    
    [HttpGet ("/api/labryinth/selectArea/{0}/{1}/{2}")]
    public IActionResult getLabyrinthSelectArea()
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
    
    [HttpGet ("/api/labryinth/clearArea/{0}/{1}/{2}")]
    public IActionResult getLabyrinthClearArea()
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
    
    [HttpGet ("/api/labryinth/purchase/{0}")]
    public IActionResult getLabyrinthPurchase()
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
    
    [HttpGet ("/api/labryinth/useTicket/{0}")]
    public IActionResult getLabyrinthUseTicket()
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
    
    [HttpGet ("/api/labryinth/shop/purchase/{0}")]
    public IActionResult getLabyrinthShopPurchase()
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
    
    [HttpGet ("/api/labryinth/totalRanking")]
    public IActionResult getLabyrinthTotalRanking()
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
    
    [HttpGet ("/api/labryinth/ranking/{0}")]
    public IActionResult getLabyrinthRanking()
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

    [HttpPost("/api/labryinth/update/{0}")]
    public IActionResult postLabyrinthUpdate()
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
    
    [HttpPost("/api/labryinth/reward/{0}")]
    public IActionResult postLabyrinthReward()
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
    
    [HttpPost("/api/labryinth/totalRankDetail")]
    public IActionResult postLabyrinthTotalRankDetail()
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
    
    [HttpPost("/api/labryinth/rankDetail")]
    public IActionResult postLabyrinthRankDetail()
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