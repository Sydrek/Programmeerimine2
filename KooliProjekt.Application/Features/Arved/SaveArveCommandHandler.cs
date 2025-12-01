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
    public class SaveArveCommandHandler : IRequestHandler<SaveArveCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveArveCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveArveCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new Arve();
            if(request.Id == 0)
            {
                await _dbContext.Arved.AddAsync(list);
            }
            else
            {
                list = await _dbContext.Arved.FindAsync(request.Id);
                //_dbContext.ToDoLists.Update(list);
            }

            list.LineItem = request.Title;
            
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
