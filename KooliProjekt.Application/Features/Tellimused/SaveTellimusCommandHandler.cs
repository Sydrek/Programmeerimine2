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

namespace KooliProjekt.Application.Features.Tellimused
{
    public class SaveTellimusCommandHandler : IRequestHandler<SaveTellimusCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveTellimusCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveTellimusCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new Tellimus();
            if(request.ID == 0)
            {
                await _dbContext.Tellimused.AddAsync(list);
            }
            else
            {
                list = await _dbContext.Tellimused.FindAsync(request.ID);
                //_dbContext.ToDoLists.Update(list);
            }

            list.InvoiceNumber = request.InvoiceNumber;
            list.InvoiceDate = request.InvoiceDate;
            list.DueDate = request.DueDate;
            list.Status = request.Status;
            list.SubTotal = request.SubTotal;
            list.ShippingTotal = request.ShippingTotal;
            list.Discount = request.Discount;
            list.GrandTotal = request.GrandTotal;
            
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
