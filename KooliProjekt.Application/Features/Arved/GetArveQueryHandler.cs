using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Arved
{
    public class GetArveQueryHandler : IRequestHandler<GetArveQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetArveQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetArveQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Arved
                .Include(list => list.Items)
                .Where(list => list.ID == request.ID)
                .Select(list => new
                {
                    ID = list.ID,
                    LineItem = list.LineItem,

                    Items = list.Items.Select(item => new
                    {
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        VatRate = item.VatRate,
                        Total = item.Total,
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
