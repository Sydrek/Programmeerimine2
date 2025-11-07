using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data
{

    public class Tellimus
    {
        public int ID { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public float SubTotal { get; set; }

        public float ShippingTotal { get; set; }

        public float Discount { get; set; }

        public float GrandTotal { get; set; }
    }
}
