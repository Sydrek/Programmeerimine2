using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{

    public class Tellimus
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        [MaxLength(15)]
        public string Status { get; set; }

        public float SubTotal { get; set; }

        public float ShippingTotal { get; set; }

        public float Discount { get; set; }

        public float GrandTotal { get; set; }
    }
}
