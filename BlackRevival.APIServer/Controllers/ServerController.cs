using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Server;
using BlackRevival.Common.Apis;
using BlackRevival.Common.InGame;
using BlackRevival.Common.Model.Models;
using BlackRevival.Common.Responses;
using BlackRevival.Network.Classes;
using BlackRevival.Network.Packets;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class ServerController : Controller
{
    private readonly ILogger<ServerController> _logger;

    public ServerController(ILogger<ServerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/api/pingServerList", Name = "PingServerList")]
    public async Task<IActionResult> PingServerList()
    {
       // RequestPingServers pingPacket = new RequestPingServers { PacketID = 1 };
       // await MasterServer.SendPacketToInstanceServer(pingPacket);

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
    
    [HttpPost("/api/ingame/create/{gamemode}", Name = "CreateGame")]
    public IActionResult PostLatency([FromBody] JsonElement json)
    {
        _logger.LogInformation(json.ToString());
        
        var req = JsonSerializer.Deserialize<BattleOptionParam>(json.ToString());
        var resp = new InGameRequestResult
        {
            isChatRestricted = false,
            ingameServerInfo = new InGameServerInfo
            {
                address = "ws://127.0.0.1:27900",
                battleSeatKey = "BattleSeat:7562069:036645d100eb29bcb9ff3018083cbf988dfa6fd8",
                roomKey = "0"
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

}