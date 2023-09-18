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
}