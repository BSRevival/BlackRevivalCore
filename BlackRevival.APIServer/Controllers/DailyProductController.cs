using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class DailyProductController : Controller
{
    [HttpGet("/api/dailyProduct/all/{uid}", Name = "GetAllDailyProducts")]
    public IActionResult GetAllDailyProducts(long uid)
    {
        DailyProductResult result = new DailyProductResult
        {
            allDailyProducts = new List<UserDailyProduct>
            {
                new UserDailyProduct
                {
                    idx = 1170178,
                    userNum = 7562069,
                    productId = "DCE25",
                    buyGoodsType = GoodsType.TICKET,
                    buySubType = "CHARACTER_EXP_25",
                    buyAmount = 5,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.GEM,
                    payAmount = 20,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170176,
                    userNum = 7562069,
                    productId = "DEM3",
                    buyGoodsType = GoodsType.ASSET,
                    buySubType = "EXPERIMENT_MEMORY",
                    buyAmount = 3,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.GOLD,
                    payAmount = 0,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170177,
                    userNum = 7562069,
                    productId = "DSG1000",
                    buyGoodsType = GoodsType.ASSET,
                    buySubType = "GOLD",
                    buyAmount = 1000,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.GEM,
                    payAmount = 10,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170179,
                    userNum = 7562069,
                    productId = "GFLR001",
                    buyGoodsType = GoodsType.ASSET,
                    buySubType = "GEM",
                    buyAmount = 100,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.LABYRINTH_POINT,
                    payAmount = 600,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170180,
                    userNum = 7562069,
                    productId = "GFLR002",
                    buyGoodsType = GoodsType.ASSET,
                    buySubType = "GEM",
                    buyAmount = 150,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.LABYRINTH_POINT,
                    payAmount = 900,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170181,
                    userNum = 7562069,
                    productId = "GFLR003",
                    buyGoodsType = GoodsType.ASSET,
                    buySubType = "GEM",
                    buyAmount = 200,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.LABYRINTH_POINT,
                    payAmount = 1200,
                    rerollCount = 0,
                    reRollMaxCount = 0,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                },
                new UserDailyProduct
                {
                    idx = 1170182,
                    userNum = 7562069,
                    productId = "RDNA001",
                    buyGoodsType = GoodsType.DNA,
                    buySubType = "JACKIE-D_GROWTH",
                    buyAmount = 1,
                    payGoodsType = GoodsType.ASSET,
                    paySubType = PurchaseMethod.GEM,
                    payAmount = 0,
                    rerollCount = 0,
                    reRollMaxCount = 3,
                    purchased = false,
                    registDtm = 1665680581000,
                    expireDtm = 1665759600000
                }
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
    
    [HttpGet("api/dailyProduct/reroll/{0}/{1}")]
    public async Task<IActionResult> getDailyProductReroll()
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