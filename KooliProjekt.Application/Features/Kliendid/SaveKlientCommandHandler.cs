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

namespace KooliProjekt.Application.Features.Kliendid
{
    public class SaveKlientCommandHandler : IRequestHandler<SaveKlientCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveKlientCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveKlientCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new Klient();
            if(request.Id == 0)
            {
                await _dbContext.Kliendid.AddAsync(list);
            }
            else
            {
                list = await _dbContext.Kliendid.FindAsync(request.Id);
                //_dbContext.ToDoLists.Update(list);
            }

            list.Name = request.Title;
            
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
