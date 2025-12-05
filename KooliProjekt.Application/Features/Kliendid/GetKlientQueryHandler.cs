using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Kliendid
{
    // 28.11
    // Kasutab IKlientRepositoryt
    public class GetKlientQueryHandler : IRequestHandler<GetKlientQuery, OperationResult<object>>
    {
        private readonly IKlientRepository _KlientRepository;

        public GetKlientQueryHandler(IKlientRepository KlientRepository)
        {
            _KlientRepository = KlientRepository;
        }

        public async Task<OperationResult<object>> Handle(GetKlientQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();
            var list = await _KlientRepository.GetByIdAsync(request.ID);

            result.Value = new // Anonymous object
            {
                ID = list.ID,
                Name = list.Name,

                Items = list.Items.Select(item => new
                {
                    Address = item.Address,
                    Email = item.Email,
                    Phone = item.Phone,
                    Discount = item.Discount,
                })
            };

            return result;
        }
    }
}
