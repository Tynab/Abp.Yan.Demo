using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yan.Demo.Request;
using Yan.Demo.Service;
using Yan.Demo.Validation;

namespace Yan.Demo.Controllers;

[Route("api/yan/demo/publisher")]
public class PublisherController : IPublisherService
{
    #region Fields
    private readonly IPublisherService _publisherService;
    #endregion

    #region Constructors
    public PublisherController(IPublisherService publisherService) => _publisherService = publisherService;
    #endregion

    #region Implements
    [HttpPost]
    [Route("shoot")]
    public async Task Shoot(MessageRequest request)
    {
        await new MessageValidator().ValidateAndThrowAsync(request);
        await _publisherService.Shoot(request);
    }
    #endregion
}
