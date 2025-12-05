using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tellimused
{
    // 28.11
    // Kasutab ITellimusRepositoryt
    public class GetTellimusQueryHandler : IRequestHandler<GetTellimusQuery, OperationResult<object>>
    {
        private readonly ITellimusRepository _TellimusRepository;

        public GetTellimusQueryHandler(ITellimusRepository TellimusRepository)
        {
            _TellimusRepository = TellimusRepository;
        }

        public async Task<OperationResult<object>> Handle(GetTellimusQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();
            var list = await _TellimusRepository.GetByIdAsync(request.ID);

            result.Value = new // Anonymous object
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
            };

            return result;
        }
    }
}