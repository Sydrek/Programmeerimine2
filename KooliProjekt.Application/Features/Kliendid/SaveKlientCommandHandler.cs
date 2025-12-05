using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Kliendid
{
    // 28.11
    // Kasutab IKlientRepositoryt
    public class SaveKlientCommandHandler : IRequestHandler<SaveKlientCommand, OperationResult>
    {
        private readonly IKlientRepository _KlientRepository;

        public SaveKlientCommandHandler(IKlientRepository KlientRepository)
        {
            _KlientRepository = KlientRepository;
        }

        public async Task<OperationResult> Handle(SaveKlientCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new KlientList();
            if (request.ID != 0)
            {
                list = await _KlientRepository.GetByIdAsync(request.ID);
            }

            list.Name = request.Name;

            await _KlientRepository.SaveAsync(list);

            return result;
        }
    }
}