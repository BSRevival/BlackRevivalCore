using BlackRevival.APIServer.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class BroadcastController : Controller
{
    [HttpGet("/api/broadcast/getInfo/{uid}", Name = "GetBroadcastInfo")]
    public IActionResult GetBroadcastInfo(long uid)
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new { },
            Eac = 0,
        });
    }
    
    [HttpGet("/api/broadcast/getAllRoom", Name = "GetAllRooms")]
    public IActionResult GetAllRooms()
    {
        var ret = new Dictionary<string,List<object>>();
        ret.Add("broadcastRoomList", new List<object>());
        return Json(new WebResponseHeader
        {
            
            Cod = 200,
            Msg = "SUCCESS",
            Rst = ret,
            Eac = 0,
        });
    }
}