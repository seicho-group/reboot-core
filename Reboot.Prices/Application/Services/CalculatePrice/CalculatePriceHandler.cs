using MediatR;

namespace Reboot.Prices.Application.Services.CalculatePrice;

public class CalculatePriceHandler: IRequestHandler<CalculatePriceRequest, int>
{
    public Task<int> Handle(CalculatePriceRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}