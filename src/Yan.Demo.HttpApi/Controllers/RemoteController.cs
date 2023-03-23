using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yan.Demo.Services;

namespace Yan.Demo.Controllers;

[Route("api/remote")]
public class RemoteController : DemoController
{
    private readonly IRemoteService _service;

    public RemoteController(IRemoteService service) => _service = service;

    [HttpGet("test")]
    public Task Test() => _service.Test();
}
