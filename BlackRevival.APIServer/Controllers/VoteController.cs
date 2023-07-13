using BlackRevival.APIServer.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class VoteController : Controller
{
    [HttpGet("/api/vote/phase", Name = "GetVotePhase")]
    public IActionResult GetVotePhase()
    {
        var result = new Dictionary<string, List<Object>>();
        result.Add("votePhaseInfo", new List<object>());
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0,
        });
    }
}