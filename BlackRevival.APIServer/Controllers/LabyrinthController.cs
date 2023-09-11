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

}