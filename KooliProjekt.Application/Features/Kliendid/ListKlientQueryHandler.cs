using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Kliendid
{
    public class ListKlientQueryHandler : IRequestHandler<ListKlientQuery, OperationResult<PagedResult<Klient>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListKlientQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<Klient>>> Handle(ListKlientQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<Klient>>();

            result.Value = await _dbContext
                .Kliendid
                .OrderBy(list => list.Name)
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}