using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Tooted
{
    // 28.11
    // Kasutab IToodeRepositoryt
    public class GetToodeQueryHandler : IRequestHandler<GetToodeQuery, OperationResult<object>>
    {
        private readonly IToodeRepository _ToodeRepository;

        public GetToodeQueryHandler(IToodeRepository ToodeRepository)
        {
            _ToodeRepository = ToodeRepository;
        }

        public async Task<OperationResult<object>> Handle(GetToodeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();
            var list = await _ToodeRepository.GetByIdAsync(request.ID);

            result.Value = new // Anonymous object
            {
                ID = list.ID,
                Name = list.Name,

                Items = list.Items.Select(item => new
                {
                    Description = item.Description,
                    FotoURL = item.FotoURL,
                    Price = item.Price,
                })
            };

            return result;
        }
    }
}
