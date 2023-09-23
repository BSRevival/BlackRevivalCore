using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class MembershipController : Controller
{
    [HttpGet ("/api/membership")]
    public IActionResult getMembership()
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