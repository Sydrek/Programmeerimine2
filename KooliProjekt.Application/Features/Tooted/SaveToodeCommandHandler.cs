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

namespace KooliProjekt.Application.Features.Tooted
{
    public class SaveToodeCommandHandler : IRequestHandler<SaveToodeCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveToodeCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveToodeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new ToodeList();
            if(request.ID == 0)
            {
                await _dbContext.Tooted.AddAsync(list);
            }
            else
            {
                list = await _dbContext.Tooted.FindAsync(request.ID);
                //_dbContext.ToDoLists.Update(list);
            }

            list.Name = request.Name;
            
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
