using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class WebAssetController : Controller
{
    private const string PromotionPathTemplate = "Promotion/{0}/{1}";

    [HttpGet("Promotion/{lang}/{FileName}")]// GET}
    public IActionResult GetPromotion(string lang, string FileName)
    {
        string filePath = string.Format(PromotionPathTemplate, lang, FileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "application/octet-stream");
    }
}