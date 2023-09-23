using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class EventController : Controller
{
    [HttpGet ("/api/event/pickup/{0}")]
    public IActionResult getEventPickup()
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
    
    [HttpGet ("/api/event/list")]
    public IActionResult getEventList()
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