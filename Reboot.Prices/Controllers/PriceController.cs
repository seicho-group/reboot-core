using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reboot.Prices.Application.Services.CalculatePrice;

namespace Reboot.Prices.Controllers;

[ApiController]
[Route("api/prices")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("calculate_price")]
    public async Task<ActionResult<int>> GetProductInfo([FromBody] CalculatePriceRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(request, cancellationToken));
    }
}
