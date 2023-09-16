using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Model;
using BlackRevival.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class MailController : Controller
{
    private readonly ILogger<MailController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;

    public MailController(ILogger<MailController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }   
    
    [HttpGet("/api/mails", Name = "RequestMailData")]
    public async Task<IActionResult> RequestMailData()
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
        var userNum = session.Session.userNum;
        var mail = await _helper.GetMailEntries(userNum);
        
        var mailResult = new MailsResult
        {
            mails = mail,
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = mailResult,
            Eac = 0
        });
    }
    
    //Read Mail
    [HttpPut("/api/mails/{mailNum}/read", Name = "ReadMail")]
    public async Task<IActionResult> ReadMail(long mailNum)
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
        var userNum = session.Session.userNum;
        var mail = await _helper.GetMailByMailID(userNum, mailNum);

        var mailList = new List<Mail>();
        mailList.Add(mail);
        
        var mailResult = new MailsResult
        {
            mails = mailList
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = mailResult,
            Eac = 0
        });
    }
    
    //Receive Attachment
    [HttpPut("/api/mails/{mailNum}/received", Name = "ReceiveAttachment")]
    public async Task<IActionResult> ReceiveAttachment(string mailNum)
    {
        //TODO: Implement attachment receiving
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }

    
    [HttpDelete("/api/mails/{mailNum}", Name = "DeleteMail")]
    public async Task<IActionResult> DeleteMail(long mailNum)
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
        var userNum = session.Session.userNum;
        await _helper.DeleteMailEntry(userNum, mailNum);

        var mail = await _helper.GetMailEntries(userNum);
        
        var mailResult = new MailsResult
        {
            mails = mail,
        };
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = mailResult,
            Eac = 0
        });

    }
    

}