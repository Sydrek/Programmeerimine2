using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Tellimused
{
    // 28.11
    // Kasutab ITellimusRepositoryt
    public class SaveTellimusCommandHandler : IRequestHandler<SaveTellimusCommand, OperationResult>
    {
        private readonly ITellimusRepository _TellimusRepository;

        public SaveTellimusCommandHandler(ITellimusRepository TellimusRepository)
        {
            _TellimusRepository = TellimusRepository;
        }

        public async Task<OperationResult> Handle(SaveTellimusCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var list = new TellimusList();
            if (request.ID != 0)
            {
                list = await _TellimusRepository.GetByIdAsync(request.ID);
            }

            list.InvoiceNumber = request.InvoiceNumber;

            await _TellimusRepository.SaveAsync(list);

            return result;
        }
    }
}
