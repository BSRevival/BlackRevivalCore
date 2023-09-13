using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class WebAssetController : Controller
{
    const string promotionPathTemplate = "Promotion/{1}/{2}";

    [HttpGet("Promotion/{lang}/{FileName}")]// GET}
    public IActionResult GetPromotion(string lang, string FileName)
    {
        string filePath = string.Format(promotionPathTemplate, lang, FileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "application/octet-stream");
    }
}