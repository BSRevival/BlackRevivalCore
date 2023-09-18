using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class CodexController : Controller
{
    private readonly ILogger<CodexController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public CodexController(ILogger<CodexController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }

    [HttpGet("/api/codex/info", Name = "GetCodex")]
    public async Task<IActionResult> GetCodexInfo()
    {
        //Get Current Date
        DateTime currentDateTime = DateTime.Now;
        string formattedDateTime = $"SUN|{currentDateTime:HH}";
        
        var session = (APISession)HttpContext.Items["Session"]!;
        var user = _helper.GetUserByNum(session.Session.userNum).Result;
        
        DateTime currentUtcDateTime = DateTime.UtcNow;

        // Specify the date you want to compare to
        DateTime targetDate = user.CreateDtm; // Change this to your desired date

        // Calculate the number of days between the current UTC date and the target date
        TimeSpan timeDifference = currentUtcDateTime - targetDate;
        int numberOfDays = timeDifference.Days;
        AcCodexApi.AcCodexInfo codexInfo = new AcCodexApi.AcCodexInfo
        {
            accountCreateYear = 2023,
            accountPeriodDays =  numberOfDays,
            weatherKey = formattedDateTime,
        };

        AcCodexApi.AcCodexInfoResult codexRes = new AcCodexApi.AcCodexInfoResult
        {
            codexInfo = codexInfo,
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = codexRes,
            Eac = 0,
        });

    }

}