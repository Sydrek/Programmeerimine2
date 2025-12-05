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

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public float SubTotal { get; set; }

        public float ShippingTotal { get; set; }

        public float Discount { get; set; }

        public float GrandTotal { get; set; }
    }
}
