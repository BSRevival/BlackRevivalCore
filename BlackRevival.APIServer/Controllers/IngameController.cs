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
    
}