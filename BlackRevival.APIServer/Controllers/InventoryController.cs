using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class InventoryController : Controller
{
    private readonly ILogger<InventoryController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public InventoryController(ILogger<InventoryController> logger, AppDbContext context )
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }


    [HttpGet("/api/inven", Name = "GetInventory")]
    public IActionResult GetInventory()
    {
        var invenRes = new InvenResult()
        {
            invenGoodsList = new List<InvenGoods>(),
            newRequestArrived = false,
            tournamentStartDtm = 1665745200000

        };
        var session = (APISession)HttpContext.Items["Session"]!;

        _helper.GetInventoryGoods(session.Session.userNum).Result.ForEach(goods =>
        {
            invenRes.invenGoodsList.Add(new InvenGoods
            {
                c = goods.Text,
                a = goods.Type,
                num = goods.Num,
                userNum = goods.UserNum,
                isActivated = goods.IsActivated,
                activated = goods.Activated
            });
        });
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = invenRes,
            Eac = 0,
        });
    }
}