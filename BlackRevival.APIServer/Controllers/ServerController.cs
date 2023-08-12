using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Server;
using BlackRevival.Common.Apis;
using BlackRevival.Network.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class ServerController : Controller
{
    [HttpGet("/api/pingServerList", Name = "PingServerList")]
    public async Task<IActionResult> PingServerList()
    {
        Packet pingPacket = new Packet { PacketID = 1 };
        await MasterServer.SendPacketToInstanceServer(pingPacket);
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
    
    //Servercheck
    [HttpGet("/api/serverCheck", Name = "ServerCheck")]
    public IActionResult ServerCheck()
    {
        var resp =  new InitApi.ServerCheckResult
        {
            beforeServerCheck = false,
            serverCheck = false,
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst =resp,
            Eac = 0
        });
    }
}