using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class TutorialController : Controller
{
    [HttpGet("/api/tutorial/list", Name = "GetTutorialList")]
    public IActionResult GetTutorialList()
    {        
        TutorialListResult result = new TutorialListResult
        {
            userTutorialList = new List<UserTutorial>
            {
                new UserTutorial { tutorial = "TUTORIAL_101", userNum = 7562069, tutorialNum = 101, cleared = true },
                new UserTutorial { tutorial = "TUTORIAL_201", userNum = 7562069, tutorialNum = 201, cleared = false },
                new UserTutorial { tutorial = "TUTORIAL_202", userNum = 7562069, tutorialNum = 202, cleared = false },
                new UserTutorial { tutorial = "TUTORIAL_301", userNum = 7562069, tutorialNum = 301, cleared = false }
            }
        };

        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0,
        });
    }
}