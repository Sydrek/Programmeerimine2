using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Features.Tellimused
{
    public class SaveTellimusCommand : IRequest<OperationResult>, ITransactional
    {
        public int ID { get; set; }

        public string InvoiceNumber { get; set; }
    }
}
