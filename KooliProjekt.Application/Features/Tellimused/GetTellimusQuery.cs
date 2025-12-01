using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Tellimused
{
    public class GetTellimusQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}
