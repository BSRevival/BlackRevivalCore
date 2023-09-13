using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class WebAssetController : Controller
{
    [HttpGet("Promotion/{lang}/{FileName}")]// GET}
    public IActionResult GetPromotion(string lang, string FileName)
    {
        string filePath = $"Promotion/{lang}/{FileName}";
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "application/octet-stream");
    }
}