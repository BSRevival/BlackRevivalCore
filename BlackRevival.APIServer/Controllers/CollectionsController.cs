using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class CollectionsController : Controller
{
    [HttpGet("/api/colletions/list", Name = "GetCollectionsList")]
    public IActionResult GetCollectionsList()
    {
        var result = new UserCollectionResult
        {
            userCollectionList = new List<UserCollection>
            {
                new() { userNum = 7562069, collection = 1000, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1001, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1002, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1003, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1004, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1005, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1006, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1007, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1008, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1100, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1101, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1102, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1103, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1104, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1105, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1106, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1107, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1108, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1109, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1110, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1111, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1200, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1201, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1202, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1203, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1204, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1205, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1206, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1207, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1208, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1209, value = 0, rewarded = false, createDtm = 1665680828000, updateDtm = 1665680828000 },
                new() { userNum = 7562069, collection = 1210, value = 0, rewarded = false, createDtm = 1665680828000, updateDtm = 1665680828000 },
                new() { userNum = 7562069, collection = 1301, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1302, value = 0, rewarded = false, createDtm = 1665680827000, updateDtm = 1665680827000 },
                new() { userNum = 7562069, collection = 1303, value = 0, rewarded = false, createDtm = 1665680828000, updateDtm = 1665680828000 },
                new() { userNum = 7562069, collection = 1304, value = 0, rewarded = false, createDtm = 1665680828000, updateDtm = 1665680828000 }
            }
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0,
        });
    }
}