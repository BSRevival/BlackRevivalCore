using System.Text.Json;
using Newtonsoft.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BlackRevival.APIServer.Controllers;

public class AuthenticateController : Controller
{
    private readonly ILogger<AuthenticateController> _logger;
    
    public AuthenticateController(ILogger<AuthenticateController> logger)
    {
        _logger = logger;
    }
    [HttpPost("/api/authenticate", Name = "Authenticate")]
    public IActionResult Authenticate([FromBody] JsonElement loginInfo)
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("loginRequest string: {QueryString}", loginInfo);

        bool PlayTutorial = false;
        UserApi.LoginResult loginResult = new UserApi.LoginResult
        {
            userStatus = "NONE",
            encryptedUserNum = "gpge76eFAEi7yfSPjTY1Ng==",
            user = new Common.Model.User
            {
                    userNum = 7562069,
                    receivePushMsg = true,
                    newPostArrived = true,
                    termsAgree = true,
                    //nickname = "ReplaceNameHere",
                    tutorialProgress = 0,
                    bgm = true,
                    soundEffect = true,
                    lastword = "How can I die here...",
                    watchword = "Come at me",
                    activeCharacterNum = 10136633,
                    appLanguageCode = "en",
                    leaguePoint = 0,
                    adViewCount = 10,
                    maxAdViewCount = 10,
                    activatedPotentialSkillId = 0,
                    researcherExp = 0,
                    researcherTitleCode = 0,
                    matchingCardCode = 0,
                    lto = false,
                    ltt = false,
                    lte = false,
                    ltf = false,
                    ltv = false,
                    ltr = false,
                    sigc = 0,
                    sigg= 0,
                    rtn = "NONE",
                    aps = 6001,
                    league = League.MOUSE5,
                    // initialize other properties as needed
                    // initialize UserAsset properties
                    gold = 10000000,
                    gem = 10000000,
                    bearPoint = 1000000,
                    credit = 0,
                    mileage = 1000000,
                    experimentMemory = 0,
                    tournamentPoint = 0,
                    tournamentTicket = 0,
                    voteTicket = 0,
                    voteStamp = 0,
                    labyrinthPoint = 0,
                    agliaScore = 0
            },
            session = Common.Model.Session.Create(7562069, 12, "20d0df97c1eaef557930b3c44e3d54afc30ec3c4"),
            userIdentity = new UserApi.UserIdentity(),
            serverCheck = false
        };
        
        if (!PlayTutorial)
            loginResult.user.nickname = "AnyNickname";
        
        loginResult.userIdentity.userNum = 7562069;
        loginResult.userIdentity.authProvider = AuthProvider.STEAM;
        loginResult.userIdentity.id = "76561197991502339";
        loginResult.userIdentity.machineNum = "2fb7df94a0449fb2a649bbf14a79266f8db42ee9";
        loginResult.userIdentity.guest = false;
        loginResult.user.userNum = 7562069;
        
        
            _logger.LogInformation("User {0} logged in.", loginResult.user.userNum);
            var response = new WebResponseHeader
            {
                Cod = 200,
                Msg = "SUCCESS",
                Rst = loginResult,
                Eac = 0
            };
            return Json(response);
    }

}