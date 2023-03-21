using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Yan.Demo.Requests;
using Yan.Demo.Services;
using Yan.Demo.Validations;

namespace Yan.Demo.Controllers;

[Route("api/yan/demo/publisher")]
public class PublisherRabbitmqController : DemoController
{
    #region Fields
    private readonly IPublisherRabbitmqService _service;
    #endregion

    #region Constructors
    public PublisherRabbitmqController(IPublisherRabbitmqService service) => _service = service;
    #endregion

    #region Implements
    [HttpPost("shoot-rabbitmq")]
    public async Task<IActionResult> Shoot([FromBody] MessageRequest request)
    {
        var vldRslt = await new MessageValidator().ValidateAsync(request);
        if (!vldRslt.IsValid)
        {
            return BadRequest(vldRslt.Errors.First().ErrorMessage);
        }
        await _service.Shoot(request);
        return Ok();
    }
    #endregion
}
