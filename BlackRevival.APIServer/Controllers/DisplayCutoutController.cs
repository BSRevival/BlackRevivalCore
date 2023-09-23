using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class DisplayCutoutController : Controller
{
    private readonly ILogger<DisplayCutoutController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;
    
    public DisplayCutoutController(ILogger<DisplayCutoutController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }
    
    [HttpGet("api/displayCutout")]
    public IActionResult getDisplayCutout()
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