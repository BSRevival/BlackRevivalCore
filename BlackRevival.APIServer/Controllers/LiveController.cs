using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class LiveController : Controller
{
    const string resourcePathTemplate = "Data/PatchData/{1}";

    [HttpGet("LIVE/11.2.00/Windows64/{FileName}")]// GET}
    public IActionResult GetResources(string FileName)
    {
        string filePath = string.Format(resourcePathTemplate, FileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "application/octet-stream");
    }
}