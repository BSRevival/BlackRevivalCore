using System.Text.Json;
using System.Text.Json.Serialization;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Model.AcE;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Character = BlackRevival.Common.Model.Character;

namespace BlackRevival.APIServer.Controllers;

public class QuestController : Controller
{
    [HttpGet("/api/quest/clear/check")]
     public async Task<IActionResult> getQuestClearCheck()
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
     
     [HttpGet("/api/quest/all")]
     public async Task<IActionResult> getQuestAll()
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
     
     [HttpGet("/api/quest/clear/{qid}")]
     public async Task<IActionResult> getQuestClearId()
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
     
     [HttpGet("/api/quest/allClear/{0}")]
     public async Task<IActionResult> getQuestAllClear()
     {
         var session = (APISession)HttpContext.Items["Session"];
        //Claim all button for the quest menu!
        //We will need to adjust the URL based on what type of the "Claim All" button is clicked
        // 1 = Daily Quest, 2 = Weekly Quest, 3 = Growth Quest, 100 = Aglaia Pass
         return Json(new WebResponseHeader
         {
             Cod = 200,
             Msg = "Not yet Implemented",
             Rst = new {},
             Eac = 0
         });
     }
     
     [HttpGet("/api/quest/gemEvent")]
     public IActionResult getQuestGemEvent()
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
     
     [HttpGet("/api/quest/voteEvent")]
     public IActionResult getQuestVoteEvent()
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
     
     [HttpGet("/api/quest/gemAccEvent")]
     public IActionResult getQuestGemAccEvent()
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

     [HttpGet("/api/quest/shareGameResult")]
     public IActionResult getShareGameResult()
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
     
     [HttpGet("/api/quest/replaceProgress/{0}")]
     public IActionResult getReplaceProgress()
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