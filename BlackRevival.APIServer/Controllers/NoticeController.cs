using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class NoticeController : Controller
{
    private const string NoticesJsonFilePath = "Data/Config/notices.json";
    private const string GachaNoticesJsonFilePath = "Data/Config/GachaNotices.json";

    private readonly ILogger<NoticeController> _logger;
    public NoticeController(ILogger<NoticeController> logger)
    {
        _logger = logger;
    }
    //There is a version of promotions api/notices/{0}/{lang]/{id} | Think it was most likely placeholder
    [HttpGet("/api/notices/PROMOTION/locale/{lang}/{id}", Name = "GetPromotion")]
    public IActionResult GetPromotion(string id, string lang)
    {
        if (!System.IO.File.Exists(NoticesJsonFilePath))
        {
            return NotFound();
        }
        string json = System.IO.File.ReadAllText(NoticesJsonFilePath);

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

        if (!System.IO.File.Exists(GachaNoticesJsonFilePath))
        {
            return NotFound();
        }
        string json = System.IO.File.ReadAllText(GachaNoticesJsonFilePath);

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