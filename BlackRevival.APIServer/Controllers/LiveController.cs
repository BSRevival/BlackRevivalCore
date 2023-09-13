using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class LiveController : Controller
{
    private const string ResourcePathTemplate = "Data/PatchData/{0}";

    [HttpGet("LIVE/11.2.00/Windows64/{fileName}")]// GET}
    public IActionResult GetResources(string fileName)
    {
        string filePath = string.Format(ResourcePathTemplate, fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "application/octet-stream");
    }
}