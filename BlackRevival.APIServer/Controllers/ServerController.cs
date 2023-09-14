using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Server;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model.Models;
using BlackRevival.Common.Responses;
using BlackRevival.Network.Classes;
using BlackRevival.Network.Packets;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class ServerController : Controller
{
    [HttpGet("/api/pingServerList", Name = "PingServerList")]
    public async Task<IActionResult> PingServerList()
    {
        RequestPingServers pingPacket = new RequestPingServers { PacketID = 1 };
        await MasterServer.SendPacketToInstanceServer(pingPacket);

        var resp = new PingServerResult
        {
            serverList = new List<PingServerData>
            {
                new()
                {
                    region = "GO",
                    regionDetail = "ap-northeast-2",
                    ipAddr = "127.0.0.1",
                }
            }
        };


        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = resp,
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