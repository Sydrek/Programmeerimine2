using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Arved
{
    // 28.11
    // Kasutab IArveRepositoryt
    public class GetArveQueryHandler : IRequestHandler<GetArveQuery, OperationResult<object>>
    {
        private readonly IArveRepository _ArveRepository;

        public GetArveQueryHandler(IArveRepository ArveRepository)
        {
            _ArveRepository = ArveRepository;
        }

        public async Task<OperationResult<object>> Handle(GetArveQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();
            var list = await _ArveRepository.GetByIdAsync(request.ID);

            result.Value = new // Anonymous object
            {
                ID = list.ID,
                LineItem = list.LineItem,

                Items = list.Items.Select(item => new
                {
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    VatRate = item.VatRate,
                    Total = item.Total,
                })
            };


            return result;
        }
    }
}