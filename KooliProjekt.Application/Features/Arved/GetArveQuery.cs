using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features.Arved
{
    public class GetArveQuery : IRequest<OperationResult<object>>
    {
        public int ID { get; set; }

    }
}
