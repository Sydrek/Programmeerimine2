using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Tooted;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Tooted
{
    public class ListToodeQueryHandler : IRequestHandler<ListToodeQuery, OperationResult<PagedResult<ToodeList>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListToodeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ToodeList>>> Handle(ListToodeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<ToodeList>>();

            result.Value = await _dbContext
                .Tooted
                .OrderBy(list => list.Name)
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}