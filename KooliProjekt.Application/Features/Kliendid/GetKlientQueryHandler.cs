using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Kliendid
{
    public class GetKlientQueryHandler : IRequestHandler<GetKlientQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetKlientQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetKlientQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Kliendid
                .Include(list => list.Items)
                .Where(list => list.ID == request.ID)
                .Select(list => new
                {
                    ID = list.ID,
                    Name = list.Name,

                    Items = list.Items.Select(item => new
                    {
                        Address = item.Address,
                        Email = item.Email,
                        Phone = item.Phone,
                        Discount = item.Discount,
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
