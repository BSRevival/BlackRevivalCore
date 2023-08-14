using System.Text.Json;
using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using BlackRevival.Common.Auth;
using BlackRevival.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackRevival.APIServer.Controllers;

public class AuthenticateController : Controller
{
    private readonly ILogger<AuthenticateController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public AuthenticateController(ILogger<AuthenticateController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }   
    
    [HttpPost("/api/authenticate", Name = "Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] JsonElement loginInfo)
    {
        var queryString = HttpContext.Request.QueryString.Value;
        _logger.LogInformation("loginRequest string: {QueryString}", loginInfo);
        
        var loginRequest = JsonSerializer.Deserialize<AuthRequest>(loginInfo.ToString());

        //Eventually do some checking for banned accounts here. 
        
        
        //Check if our user exists
        var user = _helper.GetUserByNum(long.Parse(loginRequest.userId)).Result;
        var userAsset = _helper.GetUserAssetByUserNum(long.Parse(loginRequest.userId)).Result;
        bool newUser = false;
        //If user doesnt exist lets create using default values 
        if (user == null)
        {
            newUser = true;
            _logger.LogInformation("User {0} not found. Creating a new account", loginRequest.userId);
            user = new Database.User
            {
                UserNum = long.Parse(loginRequest.userId),
                Nickname = "",
            };
            userAsset = new Database.UserAsset
            {
                UserNum = long.Parse(loginRequest.userId),
            };
            await _helper.CreateUser(user);
            await _helper.CreateUserAsset(userAsset);
            _logger.LogInformation("User {0} created.", user.UserNum);
            
            //Create the new character for the user
            var newChar = new Database.Character
            {
                UserNum = user.UserNum,
            };
            await _helper.CreateCharacter(newChar);
            _logger.LogInformation("Default char {0} created.", newChar.CharacterNum);
            //now set the activate character number
            await _helper.SetUserActiveCharacter(user.UserNum, newChar.CharacterNum);
        }
        
        //Encode the usernum to base64
        var encryptedUserNum = Convert.ToBase64String(BitConverter.GetBytes(user.UserNum));


        //bool PlayTutorial = true;
        
        UserApi.LoginResult loginResult = new UserApi.LoginResult
        {
            userStatus = "NONE",
            encryptedUserNum = encryptedUserNum,
            user = new Common.Model.User
            {
                    userNum = user.UserNum, //This Is server usernumber
                    receivePushMsg = user.ReceivePushMsg,
                    newPostArrived = user.NewPostArrived,
                    termsAgree = user.TermsAgree,
                    nickname = newUser ? "" : user.Nickname,
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
            },
            session = Common.Model.Session.Create(user.UserNum, 12, "20d0df97c1eaef557930b3c44e3d54afc30ec3c4"),
            userIdentity = new UserApi.UserIdentity(),
            serverCheck = false
        };
        
        //if (!PlayTutorial)
         //   loginResult.user.nickname = "AnyNickname";
        
        loginResult.userIdentity.userNum = long.Parse(loginRequest.userId);
        loginResult.userIdentity.authProvider = AuthProvider.DISCORD;
        loginResult.userIdentity.id = loginRequest.userId;
        loginResult.userIdentity.machineNum = loginRequest.machineNum;
        loginResult.userIdentity.guest = false;
        loginResult.user.userNum = long.Parse(loginRequest.userId);
        
        
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