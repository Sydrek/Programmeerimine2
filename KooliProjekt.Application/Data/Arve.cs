using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{

    public class Arve
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string LineItem { get; set; }

        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float VatRate { get; set; }

        public float Total { get; set; }
    }

}
