using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlackRevival.APIServer.Controllers;

public class InitController : Controller
{
    private readonly ILogger<InitController> _logger;
    
    public InitController(ILogger<InitController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/api/init", Name = "Init")]
    public IActionResult Init()
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("Query string: {QueryString}", queryString);

        InitResult result = new InitResult
        {
            hideLabyrinth = false,
            assetDownloadUrlChn = "http://127.0.0.1:10080/LIVE",
            hideContents = false,
            url = new Dictionary<string, string>
            {
                { "steamNotice", "http://steamcommunity.com/app/690510" },
                { "helpShiftJa", "https://archbears.helpshift.com/a/blacksurvival/?p=all&l=ja" },
                { "cafeDefault", "https://www.facebook.com/BlackSurvivalEN" },
                { "communityEtc", "https://www.reddit.com/r/BlackSurvival/wiki/index" },
                { "NetEaseDiscord", "https://discord.com/invite/rRkJjvzzQw" },
                { "cafeQQ", "https://www.taptap.com/app/67771/topic?type=official" },
                { "dmmPay", "https://point.dmm.com/choice/pay" },
                { "netEasePay", "https://game.boltrend.com/supportPage/en/createForm?abbr=Blacksurvival&qtype=10039" },
                { "helpShiftEn", "https://archbears.helpshift.com/a/blacksurvival/?p=all&l=en" },
                { "storeChina", "http://theblacksurvival.com/" },
                { "dmmTermPage", "http://dmg.archbears.net/termPage04.html" },
                { "steamCS", "https://game.boltrend.com/supportPage/en/services?abbr=Blacksurvival&staffId=4115293" },
                { "twitch", "https://www.twitch.tv/directory/game/Black%20Survival" },
                { "cafeNaver", "https://cafe.naver.com/blacksurvival" },
                { "dmmFAQ", "https://archbears.helpshift.com/a/blacksurvival/?p=web&l=ja" },
                { "helpShift", "https://archbears.helpshift.com" },
                { "cafeNetEase", "https://www.facebook.com/BlackSurvivalEN" },
                { "steamPatchNote", "https://archbears.helpshift.com/a/blacksurvival/?p=all" },
                { "dmmNotice", "https://archbears.helpshift.com/a/blacksurvival/?p=web&l=ja" },
                { "storeIOS", "https://itunes.apple.com/app/beullaegseobaibeol/id1131137981" },
                { "cafeJapan", "https://twitter.com/BlackSurvival_J" },
                { "storeAndroid", "https://play.google.com/store/apps/details?id=com.archbears.bs" },
                { "steamFAQ", "http://steamcommunity.com/app/690510" },
                { "chinaCS", "https://archbears.helpshift.com/a/blacksurvival/?p=all&l=zh" },
                { "helpShiftAll", "https://archbears.helpshift.com/a/blacksurvival/?p=all" }
            },
            showTransferContents = true,
            updateRecommended = false,
            hideUnpack = false,
            retryRequestPopup = true,
            hideDownload = false,
            hideProgress = false,
            assetDownloadUrlAws = "http://127.0.0.1:10800/LIVE",
            assetDownloadUrlBase = "http://127.0.0.1:10800/LIVE",
            exceptionAreaList = new List<string>()
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });

    }
    
    [HttpGet("/api/status")]
    public IActionResult getStatus()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/api/serverCheck")]
    public IActionResult getServerCheck()
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