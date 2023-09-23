using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class MiniLeagueController : Controller
{
    [HttpGet("/api/miniLeague/current", Name = "GetCurrentMiniLeague")]
    public IActionResult GetCurrentMiniLeague()
    {
        CurrentLeagueResult result = new CurrentLeagueResult
        {
            miniLeague = new MiniLeague
            {
                leagueUser = new MiniLeagueUser { groupId = 81280, tier = MiniLeagueTier.STIMULUS },
                group = new MiniLeagueGroup { memberCount = 20, tier = MiniLeagueTier.STIMULUS, expireDtm = 1633186800000 },
                myEntry = new MiniLeagueEntry { nickname = "Lynity", point = 35, rank = 18, winCount = 1 },
                entries = new List<MiniLeagueEntry>
                {
                    new MiniLeagueEntry { nickname = "\u6276\u6B87", point = 1755, rank = 1, winCount = 13 },
                    new MiniLeagueEntry { nickname = "\u8D24\u72FC\u6B27\u6B27", point = 1423, rank = 2, winCount = 4 },
                    new MiniLeagueEntry { nickname = "\u304B\u3070\u3057\u307E", point = 674, rank = 3, winCount = 5 },
                    new MiniLeagueEntry { nickname = "\uB9AC\uD504\uD06C\uB124", point = 663, rank = 4, winCount = 2 },
                    new MiniLeagueEntry { nickname = "\uB8E8\uD540\uB124\uC2A4", point = 489, rank = 5, winCount = 1 },
                    new MiniLeagueEntry { nickname = "\uC6D0\uCC54\uD604\uC6B0", point = 299, rank = 6, winCount = 3 },
                    new MiniLeagueEntry { nickname = "Sneaky Otter", point = 271, rank = 7, winCount = 4 },
                    new MiniLeagueEntry { nickname = "\u85CD\u8272\u591A\u7459\u6CB3", point = 256, rank = 8, winCount = 3 },
                    new MiniLeagueEntry { nickname = "\u5E7B\u5239\u90A3", point = 238, rank = 9, winCount = 1 },
                    new MiniLeagueEntry { nickname = "cocalime", point = 204, rank = 10, winCount = 1 },
                    new MiniLeagueEntry { nickname = "PulgHole", point = 200, rank = 11, winCount = 2 },
                    new MiniLeagueEntry { nickname = "\u96F6\u70DF\u5BB9", point = 160, rank = 12, winCount = 0 },
                    new MiniLeagueEntry { nickname = "\u6C34\u8272\u5E9F\u5F03\u7269", point = 151, rank = 13, winCount = 1 },
                    new MiniLeagueEntry { nickname = "\u767D\u820C\u70CF", point = 123, rank = 14, winCount = 1 },
                    new MiniLeagueEntry { nickname = "\u672A\u95FB\u82B1\u540D1238", point = 104, rank = 15, winCount = 0 },
                    new MiniLeagueEntry { nickname = "\u5FEB\u4E50\u7684\u5200\u5149\u54E5", point = 66, rank = 16, winCount = 1 },
                    new MiniLeagueEntry { nickname = "\u65E0\u5FC3\u68A6", point = 56, rank = 17, winCount = 0 },
                    new MiniLeagueEntry { nickname = "Lynity", point = 35, rank = 18, winCount = 1 },
                    new MiniLeagueEntry { nickname = "Ralky", point = 1, rank = 19, winCount = 0 },
                    new MiniLeagueEntry { nickname = "\u6C5F\u627F", point = 0, rank = 20, winCount = 0 }
                }
            },
            newRequestArrived = true
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0,
        });
    }
    
    [HttpGet("/api/miniLeague/join")]
    public IActionResult getJoinMiniLeague()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/miniLeague/reward")]
    public IActionResult getMiniLeagueReward()
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