using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class NoticeController : Controller
{
    private readonly ILogger<NoticeController> _logger;

    public NoticeController(ILogger<NoticeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/api/notices/PROMOTION/locale/English/{id}", Name = "GetPromotion")]
    public IActionResult GetPromotion(string id)
    {
        string json = System.IO.File.ReadAllText("Data/Config/notices.json");

        NoticeResult notices = JsonSerializer.Deserialize<NoticeResult>(json);

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = notices,
            Eac = 0
        });
    }
    
    [HttpGet("/api/notices/GACHA/locale/English/{id}", Name = "GetGacha")]
    public IActionResult GetGacha()
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("Query string: {QueryString}", queryString);

        string json = System.IO.File.ReadAllText("Data/Config/GachaNotices.json");

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