using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{

    public class TellimusList
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string InvoiceNumber { get; set; }

        public IList<TellimusItem> Items { get; set; }
        }
}
