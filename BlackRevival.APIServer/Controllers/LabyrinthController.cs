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
    
    [HttpGet ("/api/labyrinth/info/{0}")]
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

    [HttpGet ("/api/labyrinth/autoStart/{0}/{1}/{2}")]
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

    [HttpGet ("/api/labyrinth/deletePlayData/{0}")]
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
    
    [HttpGet ("/api/labyrinth/openAllArea/{0}/{1}")]
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
    
    [HttpGet ("/api/labyrinth/openArea/{0}/{1}/{2}")]
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
    
    [HttpGet ("/api/labyrinth/selectArea/{0}/{1}/{2}")]
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
    
    [HttpGet ("/api/labyrinth/clearArea/{0}/{1}/{2}")]
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
    
    [HttpGet ("/api/labyrinth/purchase/{0}")]
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
    
    [HttpGet ("/api/labyrinth/useTicket/{0}")]
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
    
    [HttpGet ("/api/labyrinth/shop")]
    public IActionResult getLabyrinthShop()
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
    
    [HttpGet ("/api/labyrinth/shop/purchase/{0}")]
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
    
    [HttpGet ("/api/labyrinth/totalRanking")]
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
    
    [HttpGet ("/api/labyrinth/ranking/{0}")]
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

    [HttpPost("/api/labyrinth/update/{0}")]
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
    
    [HttpPost("/api/labyrinth/reward/{0}")]
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
    
    [HttpPost("/api/labyrinth/totalRankDetail")]
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
    
    [HttpPost("/api/labyrinth/rankDetail")]
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