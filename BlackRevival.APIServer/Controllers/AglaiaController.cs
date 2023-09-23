using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class AglaiaController : Controller
{
    [HttpGet("/api/aglaia/pass/progress/all/{uid}", Name = "GetAglaiaPassProgress")]
    public IActionResult GetAglaiaPassProgress(string uid)
    {
        
        aglaiaPassApi.ProgressListResult progressListResult = new aglaiaPassApi.ProgressListResult
        {
            aglaiaPassProgressList = new List<AglaiaPassProgress>()
        };
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = progressListResult,
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/progress/{0}/{1}")]
    public IActionResult getAglaiaPassProgress()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/progress/add/{0}/{1}")]
    public IActionResult getAddAglaiaPassProgress()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/progress/paid/progress/{0}")]
    public IActionResult getAglaiaPassProgressPaidProgress()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/progress/paid/progress/{0}")]
    public IActionResult getAglaiaPassPaidProgress()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/progress/paid/{0}/{1}")]
    public IActionResult getAglaiaPassPaid()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/reward/add/{0}/{1}/{2}")]
    public IActionResult getAglaiaPassRewardAdd()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/aglaia/pass/reward/add/Available/{0}")]
    public IActionResult getAglaiaPassRewardAddAvailable()
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