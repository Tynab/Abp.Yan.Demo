using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Yan.Demo.Requests;
using Yan.Demo.Services;
using Yan.Demo.Validations;

namespace Yan.Demo.Controllers;

[Route("api/yan/demo/publisher")]
public class PublisherController : DemoController
{
    #region Fields
    private readonly IPublisherService _publisherService;
    #endregion

    #region Constructors
    public PublisherController(IPublisherService publisherService) => _publisherService = publisherService;
    #endregion

    #region Implements
    [HttpPost("shoot")]
    public async Task<IActionResult> Shoot([FromBody] MessageRequest request)
    {
        var vldRslt = await new MessageValidator().ValidateAsync(request);
        if (!vldRslt.IsValid)
        {
            return BadRequest(vldRslt.Errors.First().ErrorMessage);
        }
        await _publisherService.Shoot(request);
        return Ok();
    }
    #endregion
}
