using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.Common.Apis;
using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class DmmController: Controller
{
    private readonly ILogger<DmmController> _logger;
    private readonly AppDbContext _context;
    private readonly DatabaseHelper _helper;
    
    public DmmController(ILogger<DmmController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _helper = new DatabaseHelper(_context);
    }
    
    [HttpPost("api/dmm/sessionCheck")]
    public IActionResult postSessionCheck()
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