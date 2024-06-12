using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reboot.Entities.Application.Services.GetAllFabrics;

namespace Reboot.Entities.Controllers;

[ApiController]
[Route("api/entities")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("get_all_fabrics")]
    public async Task<ActionResult<GetAllFabricsResponse>> GetProductInfo([FromRoute] GetAllFabricsRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(request, cancellationToken));
    }
}