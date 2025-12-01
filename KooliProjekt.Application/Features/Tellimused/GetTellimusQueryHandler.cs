using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tellimused
{
    public class GetTellimusQueryHandler : IRequestHandler<GetTellimusQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTellimusQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetTellimusQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Tellimused
                .Include(list => list.InvoiceNumber)
                .Where(list => list.ID == request.Id)
                .Select(list => new
                {
                    Id = list.ID,
                    Title = list.InvoiceNumber,
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
