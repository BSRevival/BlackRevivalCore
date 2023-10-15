using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Roulette;
using BlackRevival.Common.GameDB.Skills;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;
    public UserController(ILogger<UserController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }

    [HttpGet("/api/users/{userNum}/potentialSkillList", Name = "GetPotentialSkillList")]
    public IActionResult GetPotentialSkillList(int userNum)
    {
        var result = new PotentialSkillListResult
        {
            perkList = new List<PerkApi.PerkPreset>
            {
                new PerkApi.PerkPreset { isDefault = true, num = 2712807, userNum = 7562069, name = "DEFAULT", category = 10001, baseFirst = 10101, baseSecond = 10201, activated = true }
            },
            list = new List<UserPotentialSkill>
            {
                new UserPotentialSkill { remainTime = 0, freeItem = true, getBattleMode = 100, skillId = 6001 }
            }
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    [HttpPost("/api/users/{userNum}/nickname/duplicationcheck", Name = "NickDuplicationCheck")]
    public IActionResult NickDuplicationCheck([FromBody] string json, int userNum)
    {
        _logger.LogInformation(json);
        bool isDuplicate = _helper.IsNicknameExists(json).Result;
        
        var result = new UserApi.ExistNickNameResult { purchaseResult = isDuplicate };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    [HttpPost("/api/users/{userNum}/initNickname", Name = "InitNickname")]
    public async Task<IActionResult> InitNickname([FromBody] string nickname, long userNum)
    {
        _logger.LogInformation(nickname);
        bool isDuplicate = _helper.IsNicknameExists(nickname).Result;
        if(!isDuplicate)
            await _helper.UpdateNickname(userNum, nickname);
        
        var result = new UserApi.NicknameModifyResult { nickname =  nickname};
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    
    [HttpPost("/api/users/{userNum}", Name = "GetUser")]
    public IActionResult GetUser([FromBody] JsonElement json, long userNum)
    {
        _logger.LogInformation(json.ToString());

        //Get a user from the database and convert it to a common.model.user
        var user = _helper.GetUserByNum(userNum).Result;
        var userAsset = _helper.GetUserAssetByUserNum(userNum).Result;
        
        var newUser = new Common.Model.User
        {
            userNum = user.UserNum, //This Is server usernumber
            receivePushMsg = user.ReceivePushMsg,
            newPostArrived = user.NewPostArrived,
            termsAgree = user.TermsAgree,
            nickname = user.Nickname,
            tutorialProgress = user.TutorialProgress,
            bgm = user.Bgm,
            soundEffect = user.SoundEffect,
            lastword = user.Lastword,
            watchword = user.Watchword,
            activeCharacterNum = user.ActiveCharacterNum,
            appLanguageCode = user.AppLanguageCode,
            leaguePoint = user.LeaguePoint,
            adViewCount = user.AdViewCount,
            maxAdViewCount = user.MaxAdViewCount,
            activatedPotentialSkillId = user.ActivatedPotentialSkillId,
            researcherExp = user.ResearcherExp,
            researcherTitleCode = user.ResearcherTitleCode,
            matchingCardCode = user.MatchingCardCode,
            lto = user.Lto,
            ltt = user.Ltt,
            lte = user.Lte,
            ltf = user.Ltf,
            ltv = user.Ltv,
            ltr = user.Ltr,
            sigc = user.Sigc,
            sigg= user.Sigg,
            rtn = user.Rtn,
            aps = user.Aps,
            league = user.League,
            // initialize other properties as needed
            // initialize UserAsset properties
            gold = userAsset.Gold,
            gem = userAsset.Gem,
            bearPoint = userAsset.BearPoint,
            credit = userAsset.Credit,
            mileage = userAsset.Mileage,
            experimentMemory = userAsset.ExperimentMemory,
            tournamentPoint = userAsset.TournamentPoint,
            tournamentTicket = userAsset.TournamentTicket,
            voteTicket = userAsset.VoteTicket,
            voteStamp = userAsset.VoteStamp,
            labyrinthPoint = userAsset.LabyrinthPoint,
            agliaScore = userAsset.AgliaScore
        };
        
        
        
       
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = newUser,
            Eac = 0
        });
    }
    
    [HttpGet("/api/users/remainFreeBpRouletteTime", Name = "GetNextBPRouletteTime")]
    public IActionResult GetNextBPRouletteTime()
    {
        var session = (APISession)HttpContext.Items["Session"];
        if (session == null)
        {
            return Json(new WebResponseHeader
            {
                Cod = 401,
                Msg = "Session Does not exist",
                Rst = null,
                Eac = 0
            });
        }

        var user = _helper.GetUserByNum(session.Session.userNum).Result;
        var cooldownTime = 60; // 1-minute
        var result = new Dictionary<string, int>() { { "remainTime", (int)Math.Max(cooldownTime - (DateTime.UtcNow - user.FreeBearRouletteDtm).TotalSeconds,0)}};
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    [HttpGet("/api/users/freeBpRoulette", Name = "FreeBPRoulette")]
    public async Task<IActionResult> FreeBPRoulette()
    {
        var session = (APISession)HttpContext.Items["Session"];
        if (session == null)
        {
            return Json(new WebResponseHeader
            {
                Cod = 401,
                Msg = "Session Does not exist",
                Rst = null,
                Eac = 0
            });
        }


        //Check if the user has enough gems
        var userAsset = _helper.GetUserAssetByUserNum(session.Session.userNum).Result;
        var user = _helper.GetUserByNum(session.Session.userNum).Result;


        var count = 1;
        var type = AcE_ROULETTE_TYPE.BEARPOINT_ROULETTE;
        var product = TableManager.productsDb.FindRouletteList(PurchaseMethod.BEARPOINT, count)
            .Find(x => ProductManager.IsAvailableProduct(x.productId, type));


        var result = new FreeBpRouletteResult();
        result.provideResult = new ProvideResult();

        //Get a random item from the pool
        result.provideResult.isDuplication = false;
        result.provideResult.creditBonusRate = 1.0f;
        result.provideResult.results = new List<ProvideResult>();
        result.lastFreeBpRouletteDtm = DateTime.UtcNow;

        await _helper.UpdateFreeBearRouletteDtm(session.Session.userNum, DateTime.UtcNow);

        RouletteData rouletteData = TableManager.productsDb.FindRouletteData(product.goods.subType);
        var outlist = (from x in rouletteData.pmf
                       where x.goods.goodsType != GoodsType.ASSET || x.ratio > 0.0
                       group x by x.goods.goodsType into g
                       select new { GType = g.Key, items = g.ToList() });

        //Copy from ProductsController
        //Get a random item from the pool
        for (int i = 0; i < count; i++)
        {
            // Reseed so it's more unpredictable
            var random = new Random(Guid.NewGuid().GetHashCode());
            // Generate a random number between 0 and 1
            var randomNumber = random.NextDouble();

            // Get a random category
            // Todo: edge case as total sum ratio of all items could be 0.999998 something...
            var randomCategory = new List<RoulettePmf>();
            var currentRng = 0.0;
            foreach (var goods in outlist)
            {
                //Console.WriteLine($"{goods.GType} | {(goods.items.Sum(x => x.ratio)):F2}");

                currentRng += goods.items.Sum(x => x.ratio);
                if (randomNumber <= currentRng)
                {
                    randomCategory = goods.items;
                    break;
                }
            }

            // Generate a random number between 0 and 1
            randomNumber = random.NextDouble();
            currentRng = 0.0;

            // Get a random item within category
            var randomItem = new RoulettePmf();
            var categoryRatio = randomCategory.Sum(x => x.ratio);
            foreach (var item in randomCategory)
            {

                //Console.WriteLine($"{item.goods} | {(item.ratio / categoryRatio):F2}");
                currentRng += item.ratio / categoryRatio;
                if (randomNumber <= currentRng)
                {
                    randomItem = item;
                    break;
                }
            }
            //Console.WriteLine($"{(currentRng * 100):F2}");
            var gachaResult = new ProvideResult();

            gachaResult.rouletteGoods = randomItem.goods;

            gachaResult.invenGoods = new()
            {
                a = randomItem.goods.amount,
                userNum = session.Session.userNum,
                c = randomItem.goods.goodsCode,
                isActivated = false,
                activated = false,
                expireDtm = DateTime.Now,
            };

            gachaResult.isDuplication = false;
            gachaResult.creditBonusRate = 1.0f;
            gachaResult.goods = randomItem.goods;

            switch (randomItem.goods.goodsType)
            {
                case GoodsType.CHARACTER_SKIN:
                case GoodsType.LIVE2D_SKIN:
                    {
                        var skin = TableManager.skinsDb.GetSkinById(int.Parse(randomItem.goods.subType));

                        var newSkin = new OwnedSkin
                        {
                            UserNum = session.Session.userNum,
                            CharacterClass = skin.characterClass,
                            CharacterSkinType = skin.characterSkinType,
                            Owned = true,
                            ActiveLive2D = true,
                            SkinEnableType = SkinEnableType.PURCHASE
                        };
                        gachaResult.characterSkin = new()
                        {
                            userNum = session.Session.userNum,
                            characterClass = (int)skin.characterClass,
                            characterSkinType = skin.characterSkinType,
                            owned = true,
                            activeLive2D = true,
                            skinEnableType = SkinEnableType.PURCHASE
                        };
                        result.provideResult.characterSkin = new()
                        {
                            userNum = session.Session.userNum,
                            characterClass = (int)skin.characterClass,
                            characterSkinType = skin.characterSkinType,
                            owned = true,
                            activeLive2D = true,
                            skinEnableType = SkinEnableType.PURCHASE
                        };
                        //Add skin to the database. 
                        await _helper.CreateOwnedSkin(newSkin);


                    }
                    break;

                case GoodsType.BACKGROUND:
                    {
                        //Add Matching Card InvenGoods based off the background
                        var matchingCard = new InvenGoods
                        {
                            a = 1,
                            userNum = session.Session.userNum,
                            c = "34-" + randomItem.goods.subType,
                            isActivated = false,
                            activated = false,
                            expireDtm = DateTime.Now,
                        };


                        await _helper.AddInventoryGoods(gachaResult.invenGoods);
                        await _helper.AddInventoryGoods(matchingCard);
                    }
                    break;

                case GoodsType.LANTERN:
                case GoodsType.FURNITURE:
                    {
                        //Add these items to the db
                        await _helper.AddInventoryGoods(gachaResult.invenGoods);

                    }
                    break;
                //Todo merging of boosters, potential skills
                case GoodsType.POTENTIAL_SKILL:
                case GoodsType.BOOSTER:
                    {
                        //Add these items to the db
                        await _helper.AddInventoryGoods(gachaResult.invenGoods);
                    }
                    break;
                case GoodsType.ASSET:
                    {
                        AssetType itemCurrencyType = AssetType.NONE;
                        Enum.TryParse(randomItem.goods.subType, out itemCurrencyType);
                        //update userasset
                        userAsset.SetAssetValue(itemCurrencyType, userAsset.GetAssetValue(itemCurrencyType) + (int)randomItem.goods.amount);
                        await _helper.UpdateUserAsset(session.Session.userNum, userAsset);
                        if (Response.Headers.ContainsKey($"X-Bs-{randomItem.goods.subType}"))
                        {
                            Response.Headers.Remove($"X-Bs-{randomItem.goods.subType}");
                        }
                        Response.Headers.Add($"X-Bs-{randomItem.goods.subType}", userAsset.GetAssetValue(itemCurrencyType).ToString());
                    }
                    break;
                default:
                    {
                        //Add these items to the db
                        await _helper.AddInventoryGoods(gachaResult.invenGoods);
                    }
                    break;
            }
            result.provideResult.results.Add(gachaResult);
        }
        return Json(new WebResponseHeader
            {
                Cod = 200,
                Msg = "SUCCESS",
                Rst = result,
                Eac = 0
            });
    }
    
    [HttpPost("/api/users/postLatency", Name = "PostLatency")]
    public IActionResult PostLatency([FromBody] JsonElement json)
    {
        _logger.LogInformation(json.ToString());

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }

    [HttpGet("/api/users/{userNum}/changePotentialSkill/{skillId}", Name = "ChangePotentialSkill")]
    public async Task<IActionResult> ChangePotentialSkill(string userNum, long skillId)
    {
        
        var result = new UserApi.LoginResult.ChangePotentialSkillResult();

        result.activatedPotentialSkillId = (int)skillId;
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    
    [HttpPost("/api/user/latency", Name = "Latency")]
    public async Task<IActionResult> Latency([FromBody] JsonElement json)
    {
        _logger.LogInformation(json.ToString());

        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }

    [HttpGet ("/api/users/{UserNum}/histories")]
    public IActionResult getMatchHistory()
    {
        var session = (APISession)HttpContext.Items["Session"];
        //Buying a new new research result slot
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    } 
    
    [HttpPost ("/api/isGuest")]
    public IActionResult postIsGuest()
    {
        var session = (APISession)HttpContext.Items["Session"];
        //Tell the server if we're logging in as a guest. Shouldn't be possible for us
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/login")]
    public IActionResult postLogin()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpDelete ("/api/users/{0}/delete")]
    public IActionResult deleteAssets()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{1}/edit")]
    public IActionResult getEdit()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/edit/cancelUpgradeLeave")]
    public IActionResult getCancelUpgradeLeague()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }

    [HttpGet ("/api/users/{0}/edit/sendValidationCode")]
    public IActionResult getSendValidationCode()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/edit/receiveValidationCode/{1}")]
    public IActionResult getReceiveValidationCode()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/edit/selectDairyCharacter/{1}")]
    public IActionResult getSelectDairyCharacter()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/deadCharacter")]
    public IActionResult getDeadCharacter()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/users/{0}/changePerk")]
    public IActionResult postChangePerk()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/users/{0}/authProvicer/token")]
    public IActionResult postAuthProvicerToken()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPost ("/api/users/{0}/leave")]
    public IActionResult postLeave()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpPut ("/api/users/{0}/usehack")]
    public IActionResult putRecord()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/firstInAppEvent/{0}")]
    public IActionResult getFirstInAppEvent()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/playCount")]
    public IActionResult getPlayCount()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/record/{1}")]
    public IActionResult getUsersRecord()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/checkUserNum")]
    public IActionResult getCheckUserNum()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/freeRevival/{1}")]
    public IActionResult getFreeRevival()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/updateAdCount")]
    public IActionResult getUpdateAdCount()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/histories")]
    public IActionResult getHistory()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
    
    [HttpGet ("/api/users/{0}/search")]
    public IActionResult getUserSearch()
    {
        var session = (APISession)HttpContext.Items["Session"];
        
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "Not yet Implemented",
            Rst = new {},
            Eac = 0
        });
    }
}