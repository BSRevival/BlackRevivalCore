using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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

    //We have api/inven/{0} in the missing end points list, I presume this is just the same thing
    [HttpGet("/api/inven", Name = "GetInventory")]
    public IActionResult GetInventory()
    {
        var invenRes = new InvenResult()
        {
            invenGoodsList = new List<InvenGoods>(),
            newRequestArrived = false,
            tournamentStartDtm = DateTime.Now

        };
        var session = (APISession)HttpContext.Items["Session"]!;

        _helper.GetInventoryGoods(session.Session.userNum).Result.ForEach(goods =>
        {
            invenRes.invenGoodsList.Add(new InvenGoods
            {
                c = goods.Text,
                a = goods.Amount,
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

    [HttpPost("/api/inven/updateActive")]

    public async Task<IActionResult> updateActiveItems([FromBody] JsonElement updateItems)
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        
        //Get all the items first and then update them
        //We need to get the result from the body and then parse them into a list of InvenGoods
        _logger.LogInformation("updateActiveItems string: {QueryString}", updateItems);
        List<InvenGoods> goodsList = JsonSerializer.Deserialize<List<InvenGoods>>(updateItems.ToString());
        
        //Now we need to update the items in the database
        goodsList.ForEach(goods =>
        {
            _helper.ChangeItemActivation(goods.num, goods.isActivated).Wait();
        });
        
        var invenRes = new InvenResult()
        {
            invenGoodsList = new List<InvenGoods>(),
            newRequestArrived = false,
            tournamentStartDtm = DateTime.Now

        };

        _helper.GetInventoryGoods(session.Session.userNum).Result.ForEach(goods =>
        {
            invenRes.invenGoodsList.Add(new InvenGoods
            {
                c = goods.Text,
                a = goods.Amount,
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
    
    
    
    [HttpGet("/api/lab/get/{labnumber}", Name = "GetLabChange")]
    public async Task<IActionResult> GetLabChange(int labnumber)
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        
        
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0,
        });
    }
    
    [HttpGet("/api/lab/all/{usernum}", Name = "GetAllLabByUser")]
    public async Task<IActionResult> GetAllLabByUser(long usernum)
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        
        
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0,
        });
    }

    [HttpPost("/api/lab/set/{labnumber}", Name = "SetLab")]
    public async Task<IActionResult> SetLab(long labnumber, [FromBody] JsonElement lab)
    {
        var session = (APISession)HttpContext.Items["Session"]!;
        _logger.LogInformation("SetLab string: {QueryString}", lab);


        //Get all items first then update them
        LabGoods goodsList = JsonSerializer.Deserialize<LabGoods>(lab.ToString());
        //First check if any components in the lab are active and not in the goodslist
        var labInfo = await _helper.GetLab(labnumber);

        //Lets check if we have any active components that are not in the goodslist
        //We must split the components into a list of longs
        //Make sure components is not empty
        List<long> activeComponents = new List<long>();
        if (labInfo.components != "")
        {
            string[] activeComponentsString = labInfo.components.Split(",");
            foreach (string s in activeComponentsString)
            {
                activeComponents.Add(long.Parse(s));
            }

            //Now we have a list of active components, lets check if any of them are not in the goodslist
            foreach (long l in activeComponents)
            {
                if (!goodsList.invenGoodsList.Exists(x => x == l))
                {
                    //We have a component that is active but not in the goodslist, lets deactivate it
                    await _helper.ChangeItemActivation(l, false);
                }
            }
        }

        //Now lets activate all the items in the goodslist
        goodsList.invenGoodsList.ForEach(goods =>
        {
            _helper.ChangeItemActivation(goods, true).Wait();
        });
        
        //Now lets update the lab
        await _helper.UpdateLab(labnumber, goodsList);
        
        //now return an inven result
        var invenRes = new InvenResult()
        {
            invenGoodsList = new List<InvenGoods>(),
            newRequestArrived = false,
            tournamentStartDtm = DateTime.Now

        };
        
        _helper.GetInventoryGoods(session.Session.userNum).Result.ForEach(goods =>
        {
            invenRes.invenGoodsList.Add(new InvenGoods
            {
                c = goods.Text,
                a = goods.Amount,
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
    
    [HttpGet("/inven/use/{0}/{1}")]
    public IActionResult getInventoryUse()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/inven/sell/{0}/{1}")]
    public IActionResult getInventorySell()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/lab/main/{0}")]
    public IActionResult getMainLab()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/lab/new/{0}/{1}")]
    public IActionResult getNewLab()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/lab/production/start/{0}")]
    public IActionResult getStartProduction()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet("/lab/production/acquire/{0}")]
    public IActionResult getProductionAcquire()
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