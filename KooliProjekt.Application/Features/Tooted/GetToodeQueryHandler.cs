using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tooted
{
    public class GetToodeQueryHandler : IRequestHandler<GetToodeQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetToodeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetToodeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Tooted
                .Include(list => list.Items)
                .Where(list => list.ID == request.ID)
                .Select(list => new
                {
                    ID = list.ID,
                    Name = list.Name,

                    Items = list.Items.Select(item => new
                    {
                        Description = item.Description,
                        FotoURL = item.FotoURL,
                        Price = item.Price,
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
