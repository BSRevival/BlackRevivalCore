using System.Text.Json.Nodes;
using BlackRevival.APIServer.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class MetadataController : Controller
{
    const string metaDataPathTemplate = "data/GameDB/{1}.json";

    private readonly ILogger<MetadataController> _logger;
    public MetadataController(ILogger<MetadataController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/api/metaData/hash", Name = "GetMetaDataChecksum")]
    public IActionResult GetMetaDataChecksum()
    {
        var data = new Dictionary<string, long>
        {
            { "expeditionArea", 2497034735 },
            { "expeditionSkill", 2012329204 },
            { "expeditionEnemyGroup", 445964749 },
            { "webResource", 3495377667 },
            { "signature", 1266420709 },
            { "radarMinMax", 236026859 },
            { "preset", 617090108 },
            { "quest", 2332923331 },
            { "expeditionUnit", 3454411765 },
            { "character", 263111916 },
            { "attendanceEvent", 1006069378 },
            { "avatarBonus", 1460219137 },
            { "miniLeague", 2615343674 },
            { "expeditionEvent", 3861349004 },
            { "skill", 2457923802 },
            { "perk", 952561296 },
            { "tutorial", 4288244954 },
            { "gacha", 479887755 },
            { "constants", 688682256 },
            { "vote", 1770788980 },
            { "expeditionCard", 1975305243 },
            { "expTable", 2693631609 },
            { "item", 2042719681 },
            { "product", 3247076470 },
            { "aglaiaPass", 2606242170 },
            { "league", 3542305455 },
            { "collection", 41317042 },
            { "researcherLevel", 1573952504 },
            { "monster", 2732406530 },
            { "battle", 717919958 },
            { "field", 4156588914 },
            { "unitStat", 4122206408 },
            { "sns", 628188196 },
            { "expeditionMastery", 1138951080 }
        };

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = data,
            Eac = 0
        });
    }

    [HttpGet("/api/metaData/{metaData}", Name = "GetMetaData")]

    // GET
    public IActionResult GetMetaData(string metaData)
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("Query string: {QueryString}", queryString);

        string metaDataPath = string.Format(metaDataPathTemplate, metaData);
        if (!System.IO.File.Exists(metaDataPath))
        {
            return NotFound();
        }
        var file = System.IO.File.ReadAllText(metaDataPath);
        var jsonObj = JsonNode.Parse(file).AsObject();

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = jsonObj,
            Eac = 0
        });
    }
}