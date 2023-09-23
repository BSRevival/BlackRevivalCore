using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class PerkController: Controller
{
    [HttpGet ("/api/perk/new/{user.UserNum}")]
    public async Task<IActionResult> getNewPerkSlot()
    {
        var session = (APISession)HttpContext.Items["Session"];
        //Buying a new new research result slot
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/perk/all/{0}")]
    public IActionResult getAllPerks()
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
    
    [HttpPost ("/api/perk/set/{0}")]
    public IActionResult postSetPerk()
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