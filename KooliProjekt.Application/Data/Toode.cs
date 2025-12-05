using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{

    public class Toode
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [MaxLength(255)]
        [MinLength(0)]
        public string Description { get; set; }

        [MaxLength(255)]
        [MinLength(0)]
        public string FotoURL { get; set; }

        public int Price { get; set; }
    }
}
