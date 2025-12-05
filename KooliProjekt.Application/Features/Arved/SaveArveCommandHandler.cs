using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KooliProjekt.Application.Features.Arved
{
    public class SaveToDoListCommandHandler : IRequestHandler<SaveArveCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveToDoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveArveCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new ArveList();
            if (request.ID == 0)
            {
                await _dbContext.Arved.AddAsync(list);
            }
            else
            {
                list = await _dbContext.Arved.FindAsync(request.ID);
            }

            list.LineItem = request.LineItem;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}