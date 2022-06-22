using Child;
using Microsoft.AspNetCore.Mvc;

namespace SampleDynamicWebApi.Controllers;

[Route("api/v1/sample")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly IChildService _childService;

    public SampleController(IChildService childService)
    {
        _childService = childService;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        _childService.CallMe();
        return Ok();
    }
}