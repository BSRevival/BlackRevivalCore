using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class WebAssetController : Controller
{
 
    [HttpGet("Promotion/{lang}/{FileName}")]// GET}
    public IActionResult GetPromotion(string lang,string FileName)
    {
        var b = System.IO.File.ReadAllBytes($"Promotion/{lang}/{FileName}");
        return File(b, "application/octet-stream");
    }
}