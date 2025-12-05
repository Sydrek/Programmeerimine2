using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features.Tooted
{
    public class SaveToodeCommand : IRequest<OperationResult>, ITransactional
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
