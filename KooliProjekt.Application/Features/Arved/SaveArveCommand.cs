using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features.Arved
{
    public class SaveArveCommand : IRequest<OperationResult>, ITransactional
    {
        public int ID { get; set; }

        public string LineItem { get; set; }

        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float VatRate { get; set; }

        public float Total { get; set; }
    }
}
