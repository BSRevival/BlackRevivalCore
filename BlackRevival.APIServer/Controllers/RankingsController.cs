using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Roulette;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class RankingsController : Controller
{
    private readonly ILogger<RankingsController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public RankingsController(ILogger<RankingsController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }    
    
    [HttpGet("/api/rankings/league")]
    public IActionResult getRankingLeague()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/rankings/top/{0}")]
    public IActionResult getTopRankings()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/rankings/honor/{0}/{1}")]
    public IActionResult getHonorRankings()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
}