using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class CommunityController : Controller
{
    [HttpGet("/api/community/friend/list/{userNum}")]
    public IActionResult getFriendsList()
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        var userFriendList = "{\"userFriendList\":[{\"batch\":false,\"idx\":6768,\"unm\":2863408,\"funm\":1047562,\"nnm\":\"Tsubominokokoro\",\"rtc\":0,\"leg\":30,\"lrp\":3029,\"bat\":false,\"rlv\":116,\"fav\":false,\"fpt\":0,\"adtm\":1566688307000,\"lpdtm\":1656809874000,\"lldtm\":1656809903000,\"rtn\":\"NONE\",\"rtt\":{\"c\":0,\"t\":\"NONE\",\"tex\":\"\"}},{\"batch\":false,\"idx\":12780,\"unm\":2863408,\"funm\":3162383,\"nnm\":\"dtm04\",\"rtc\":0,\"leg\":32,\"lrp\":3187,\"bat\":false,\"rlv\":51,\"fav\":false,\"fpt\":0,\"adtm\":1575517434000,\"lpdtm\":1664288466000,\"lldtm\":1664399894000,\"rtn\":\"NONE\",\"rtt\":{\"c\":0,\"t\":\"NONE\",\"tex\":\"\"}},{\"batch\":false,\"idx\":12816,\"unm\":2863408,\"funm\":3207213,\"nnm\":\"SumisCloud\",\"rtc\":0,\"leg\":38,\"lrp\":3792,\"bat\":false,\"rlv\":101,\"fav\":false,\"fpt\":0,\"adtm\":1575596295000,\"lpdtm\":1652492696000,\"lldtm\":1652492729000,\"rtn\":\"NONE\",\"rtt\":{\"c\":0,\"t\":\"NONE\",\"tex\":\"\"}},{\"batch\":false,\"idx\":6672,\"unm\":2863408,\"funm\":3902986,\"nnm\":\"LunarDiscord\",\"rtc\":0,\"leg\":38,\"lrp\":3772,\"bat\":false,\"rlv\":123,\"fav\":false,\"fpt\":0,\"adtm\":1566596776000,\"lpdtm\":1645232711000,\"lldtm\":1652393280000,\"rtn\":\"NONE\",\"rtt\":{\"c\":0,\"t\":\"NONE\",\"tex\":\"\"}},{\"batch\":false,\"idx\":6674,\"unm\":2863408,\"funm\":4264196,\"nnm\":\"Tlieh\",\"rtc\":0,\"leg\":44,\"lrp\":4446,\"bat\":false,\"rlv\":146,\"fav\":false,\"fpt\":0,\"adtm\":1566601101000,\"lpdtm\":1665665465000,\"lldtm\":1665665486000,\"rtn\":\"NONE\",\"rtt\":{\"c\":0,\"t\":\"NONE\",\"tex\":\"\"}}],\"tournamentStartDtm\":1665918000000},\"eac\":0}";
        //TODO:
        //Create Community | Friends DB
        //Load Data from DB (Friend Name | Rank | Last Login time)
        return Json(new WebResponseHeader
        {   
            Cod = 200,
            Msg = "Not yet Implemented | Placeholder Data",
            Rst = userFriendList,
            Eac = 0,
        }); 
    }
    
    [HttpGet("/api/community/request/sendList/{userNum}")]
    public async Task<IActionResult> getSendList()
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        
        return Json(new WebResponseHeader
        {   
            Cod = 200,
            Msg = "Not yet Implemented",
            Eac = 0,
        }); 
    }
    
    [HttpGet("/api/community/request/receiveList/{userNum}")]
    public async Task<IActionResult> getReceiveList()
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        
        return Json(new WebResponseHeader
        {   
            Cod = 200,
            Msg = "Not yet Implemented",
            Eac = 0,
        }); 
    }
    
    [HttpGet("/api/esoul/registration/issue")]
    public IActionResult getEsoulRegistrationIssue()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/esoul/domain/{0}")]
    public IActionResult postEsoulDomain()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/find/{1}/{0}")]
    public IActionResult getFindFriend1()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/find/{0}")]
    public IActionResult getFindFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/add/{0}/{1}")]
    public IActionResult getAddFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/cancel/{0}/{1}")]
    public IActionResult getCancelFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/accept/{0}/{1}")]
    public IActionResult getAcceptFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/friend/reject/{0}/{1}")]
    public IActionResult getRejectFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/request/clearReceiveList/{0}")]
    public IActionResult getClearReceiveList()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/community/friend/delete/{0}")]
    public IActionResult postDeleteFriend()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost("/api/community/game/invite/")]
    public IActionResult postGameInvite()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/game/invite/{0}/{1}")]
    public IActionResult getGameInvite()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/game/accept/{0}/{1}")]
    public IActionResult getGameAccept()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/game/reject/{0}/{1}")]
    public IActionResult getGameReject()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/community/request/receiveCheck/{0}")]
    public IActionResult getReceiveCheck()
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