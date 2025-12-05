using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{

    public class Klient
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Email { get; set; }

        [MaxLength(15)]
        [MinLength(0)]
        public string Phone { get; set; }

        public float Discount { get; set; }
    }
}
