using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace KooliProjekt.Application.Features.Tellimused
{
    public class GetTellimusQueryHandler : IRequestHandler<GetTellimusQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTellimusQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetTellimusQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Tellimused
                .Include(list => list.Items)
                .Where(list => list.ID == request.ID)
                .Select(list => new
                {
                    ID = list.ID,
                    Name = list.InvoiceNumber,

                    Items = list.Items.Select(item => new
                    {
                        InvoiceDate = item.InvoiceDate,
                        DueDate = item.DueDate,
                        Status = item.Status,
                        SubTotal = item.SubTotal,
                        ShippingTotal = item.ShippingTotal,
                        Discount = item.Discount,
                        GrandTotal = item.GrandTotal,
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
