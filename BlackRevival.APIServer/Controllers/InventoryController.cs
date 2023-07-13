using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class InventoryController : Controller
{

    [HttpGet("/api/inven", Name = "GetInventory")]
    public IActionResult GetInventory()
    {
        var invenRes = new InvenResult()
        {
            invenGoodsList = new List<InvenGoods>
            {
                new InvenGoods
                {
                    c = "12-LABYRINTH_TICKET",
                    a = 3,
                    num = 3517694,
                    userNum = 7562069,
                    isActivated = false,
                    activated = false,
                }
            },
            newRequestArrived = false,
            tournamentStartDtm = 1665745200000

        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = invenRes,
            Eac = 0,
        });
    }
}