using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class ScenarioController : Controller
{
    private readonly ILogger<ScenarioController> _logger;

    public ScenarioController(ILogger<ScenarioController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("/api/scenario/clearedScenario", Name = "GetClearedTasks")]
    public IActionResult GetClearedTasks()
    { 
        var taskData = new TaskResult
        {
            tasks = new List<TaskSummary>
            {
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 10101,
                    actNum = 1,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)1,
                    playable = true,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 20001,
                    actNum = 2,
                    startTermTaskNum = 10101,
                    startTermActType = (ActType)1,
                    actType = (ActType)2,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 30001,
                    actNum = 1,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)3,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 30002,
                    actNum = 2,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)3,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 30003,
                    actNum = 3,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)3,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 30004,
                    actNum = 4,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)3,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                },
                new TaskSummary
                {
                    userNum = 7562069,
                    taskNum = 30005,
                    actNum = 5,
                    startTermTaskNum = 0,
                    startTermActType = 0,
                    actType = (ActType)3,
                    playable = false,
                    clearedCount = 0,
                    cleared = false
                }
            }
        };
               
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = taskData,
            Eac = 0
        });
    }
}