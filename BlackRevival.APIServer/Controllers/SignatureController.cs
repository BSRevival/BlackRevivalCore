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

public class SignatureController : Controller
{
    [HttpGet ("/api/signature/info/{0}")]
    public IActionResult getSignatureInfo()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/signature/make/{0}/{1}/{2}")]
    public IActionResult getSignatureMake()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/signature/decompose/{0}/{1}/{2}")]
    public IActionResult getSignatureDecompose()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/signature/decompose/batch")]
    public IActionResult postSignatureDecompose()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/signature/upgrade/{0}/{1}")]
    public IActionResult getSignatureUpgrade()
    {
        var session = (APISession)HttpContext.Items["Session"];
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
}