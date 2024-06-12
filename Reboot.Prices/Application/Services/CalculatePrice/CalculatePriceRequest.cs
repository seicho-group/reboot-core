using MediatR;

namespace Reboot.Prices.Application.Services.CalculatePrice;

public class CalculatePriceRequest : IRequest<int>
{
    public Guid OfferId { get; set; }
    public Guid ModelId { get; set; }
}