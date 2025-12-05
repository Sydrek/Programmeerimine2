using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Tooted
{
    // 28.11
    // Kasutab IToodeRepositoryt
    public class SaveToodeCommandHandler : IRequestHandler<SaveToodeCommand, OperationResult>
    {
        private readonly IToodeRepository _ToodeRepository;

        public SaveToodeCommandHandler(IToodeRepository ToodeRepository)
        {
            _ToodeRepository = ToodeRepository;
        }

        public async Task<OperationResult> Handle(SaveToodeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new ToodeList();
            if (request.ID != 0)
            {
                list = await _ToodeRepository.GetByIdAsync(request.ID);
            }

            list.Name = request.Name;

            await _ToodeRepository.SaveAsync(list);

            return result;
        }
    }
}
