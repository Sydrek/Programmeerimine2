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
                .Include(list => list.LineItem)
                .Where(list => list.ID == request.Id)
                .Select(list => new
                {
                    Id = list.ID,
                    Title = list.LineItem,
                    UnitPrice = list.UnitPrice,
                    Quantity = list.Quantity,
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
