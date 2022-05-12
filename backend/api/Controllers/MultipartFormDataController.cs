using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class MultipartFormDataController : ControllerBase
{
  private readonly ILogger<MultipartFormDataController> _logger;

  public MultipartFormDataController(ILogger<MultipartFormDataController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  public ActionResult Post([FromForm]ImageData formData)
  {
    _logger.LogInformation("FileName: {name} Length: {length}", formData.file?.FileName, formData.file?.Length);
    return CreatedAtAction("Post", new {
      FileName = formData.file?.FileName,
      Length = formData.file?.Length,
      Id = formData.Id
    }); 
  }

  public class ImageData {
    public IFormFile? file { get; set; }
    public int Id { get; set;}
  }
}
