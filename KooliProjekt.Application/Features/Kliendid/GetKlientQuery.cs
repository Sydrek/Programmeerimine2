using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Kliendid
{
    public class GetKlientQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}
