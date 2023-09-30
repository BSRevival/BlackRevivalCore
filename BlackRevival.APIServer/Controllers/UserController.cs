using System.Text.Json;
using System.Text.Json.Serialization;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
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
        //This just sets it so that its always active
        var result = new Dictionary<string, int>() { { "remainTime", 0 } };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = result,
            Eac = 0
        });
    }
    [HttpGet("/api/users/freeBpRoulette", Name = "FreeBPRoulette")]
    public IActionResult FreeBPRoulette()
    {
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
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