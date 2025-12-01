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

namespace KooliProjekt.Application.Features.Tellimused
{
    public class ListTellimusQueryHandler : IRequestHandler<ListTellimusQuery, OperationResult<PagedResult<Tellimus>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTellimusQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<Tellimus>>> Handle(ListTellimusQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<Tellimus>>();

            result.Value = await _dbContext
                .Tellimused
                .OrderBy(list => list.InvoiceNumber)
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}