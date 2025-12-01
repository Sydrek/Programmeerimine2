using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Tooted
{
    public class GetToodeQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}
