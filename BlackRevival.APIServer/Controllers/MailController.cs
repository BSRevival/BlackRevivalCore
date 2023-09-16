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
        /*
        var mail = await _helper.GetMailByNum(userNum, mailNum);
        var mailAttachment = await _helper.GetMailAttachmentByMailNum(userNum, mailNum);
        var mailAttachmentList = new List<MailAttachment>();
        if (mailAttachment != null)
        {
            mailAttachmentList.Add(mailAttachment);
        }
        var mailList = new List<Mail>();
        if (mail != null)
        {
            mailList.Add(mail);
        }
        
        */
        
        //TODO: Implement mail system
        //Send empty mail list for now
        var mailResult = new MailsResult
        {
            mails = new List<Mail>(),
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
    public async Task<IActionResult> ReadMail(string mailNum)
    {
        //TODO: Implement Read mail
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
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
    public async Task<IActionResult> DeleteMail(string mailNum)
    {
        //TODO: Implement mail deletion
        return Json(new WebResponseHeader
        {
            Cod = 200,
            Msg = "SUCCESS",
            Rst = new {},
            Eac = 0
        });
    }
    

}