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

namespace KooliProjekt.Application.Features.Arved
{
    public class ListArveQueryHandler : IRequestHandler<ListArveQuery, OperationResult<PagedResult<ArveList>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListArveQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ArveList>>> Handle(ListArveQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<ArveList>>();

            result.Value = await _dbContext
                .Arved
                .OrderBy(list => list.LineItem)
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}