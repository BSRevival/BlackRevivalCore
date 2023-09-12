using Microsoft.AspNetCore.Mvc;

namespace BlackRevival.APIServer.Controllers;

public class LiveController : Controller
{
    [HttpGet("LIVE/11.2.00/Windows64/{FileName}")]// GET}
    public IActionResult GetResources(string FileName)
	{
		if (!System.IO.File.Exists($"Data/PatchData/{FileName}"))
		{
			return NotFound();
		}
		var b = System.IO.File.ReadAllBytes($"Data/PatchData/{FileName}");
        return File(b, "application/octet-stream");
    }
}