using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlackRevival.APIServer.Controllers;

public class NoticeController : Controller
{
    const string noticesJsonFilePath = "Data/Config/notices.json";
    const string gachaNoticesJsonFilePath = "Data/Config/GachaNotices.json";

    private readonly ILogger<NoticeController> _logger;
    public NoticeController(ILogger<NoticeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/api/notices/PROMOTION/locale/{lang}/{id}", Name = "GetPromotion")]
    public IActionResult GetPromotion(string id, string lang)
    {
        if (!System.IO.File.Exists(noticesJsonFilePath))
        {
            return NotFound();
        }
        string json = System.IO.File.ReadAllText(noticesJsonFilePath);

        NoticeResult notices = JsonSerializer.Deserialize<NoticeResult>(json);

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = notices,
            Eac = 0
        });
    }

    [HttpGet("/api/notices/GACHA/locale/{lang}/{id}", Name = "GetGacha")]
    public IActionResult GetGacha(string id, string lang)
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("Query string: {QueryString}", queryString);

        if (!System.IO.File.Exists(gachaNoticesJsonFilePath))
        {
            return NotFound();
        }
        string json = System.IO.File.ReadAllText(gachaNoticesJsonFilePath);

        NoticeResult notices = JsonSerializer.Deserialize<NoticeResult>(json);

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = notices,
            Eac = 0
        });
    }

}