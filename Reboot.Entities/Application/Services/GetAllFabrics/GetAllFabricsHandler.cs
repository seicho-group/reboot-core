using MediatR;
using Microsoft.EntityFrameworkCore;
using Reboot.DB.Domain.Context;

namespace Reboot.Entities.Application.Services.GetAllFabrics;

public class GetAllFabricsHandler(RebootDatabaseContext dbContent) : IRequestHandler<GetAllFabricsRequest, GetAllFabricsResponse>
{
    public async Task<GetAllFabricsResponse> Handle(GetAllFabricsRequest request, CancellationToken cancellationToken)
    {
        var fabrics = await dbContent.PhoneFabrics.ToListAsync(cancellationToken);
        return new GetAllFabricsResponse() {Rows = fabrics};
    }
}