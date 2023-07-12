using BlackRevival.APIServer.Classes;
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
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/users/{userNum}", Name = "GetUser")]
    public IActionResult GetUser(int userNum)
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/users/remainFreeBpRouletteTime", Name = "GetNextBPRouletteTime")]
    public IActionResult GetNextBPRouletteTime()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
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