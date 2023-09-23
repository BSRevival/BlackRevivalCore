using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BlackRevival.APIServer.Controllers;

public class NavpresetController : Controller
{
    [HttpGet ("/api/navpreset/")]
    public IActionResult getNavPreset()
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
    
    [HttpPost ("/api/navpreset/")]
    public IActionResult postNavPreset()
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
    
    [HttpGet ("/api/navpreset/group/add/{0}")]
    public IActionResult getNavPresetGroupAdd()
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
    
    [HttpGet ("/api/navpreset/group/reset/{0}")]
    public IActionResult getNavPresetGroupReset()
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
    
    [HttpPost ("/api/navpreset/group/")]
    public IActionResult postNavPresetGroup()
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