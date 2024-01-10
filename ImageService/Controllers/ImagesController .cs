// ImagesController.cs
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public ImagesController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("upload")]
    public IActionResult UploadImage(IFormFile file)
    {
        try
        {
            //var file = Request.Form.Files[0];

            if (file == null || file.Length == 0 || string.IsNullOrEmpty(file.FileName))
            {
                return BadRequest(new { message = "No valid file uploaded" });
            }

            var fileName = Path.GetFileName(file.FileName);

            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest(new { message = "Invalid file name" });
            }
            var newfileName = string.Concat(DateTime.Now.Ticks, file.FileName);
            var filePath = Path.Combine(_environment.ContentRootPath, "uploads", newfileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var imageUrl = $"{Request.Scheme}://{Request.Host}/{"api/images"}/{newfileName}";
            
            return Ok(new { message = "Image uploaded successfully", imageUrl = imageUrl });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error uploading image", error = ex.Message });
        }
    }
        
    [HttpGet("{imageName}")]
    public IActionResult Get(string imageName)
    {
        var filePath = Path.Combine(_environment.ContentRootPath, "uploads", imageName);
        var image = System.IO.File.OpenRead(filePath);
        return File(image, "image/jpeg");
    }

}
