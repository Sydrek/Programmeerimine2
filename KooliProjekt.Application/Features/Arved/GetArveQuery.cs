using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Arved
{
    public class GetArveQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}
