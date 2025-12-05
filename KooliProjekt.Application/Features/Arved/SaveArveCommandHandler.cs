using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Arved
{
    // 28.11
    // Kasutab IArveRepositoryt
    public class SaveArveCommandHandler : IRequestHandler<SaveArveCommand, OperationResult>
    {
        private readonly IArveRepository _ArveRepository;

        public SaveArveCommandHandler(IArveRepository ArveRepository)
        {
            _ArveRepository = ArveRepository;
        }

        public async Task<OperationResult> Handle(SaveArveCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new ArveList();
            if (request.ID != 0)
            {
                list = await _ArveRepository.GetByIdAsync(request.ID);
            }

            list.LineItem = request.LineItem;

            await _ArveRepository.SaveAsync(list);

            return result;
        }
    }
}
