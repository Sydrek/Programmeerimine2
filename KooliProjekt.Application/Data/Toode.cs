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
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FotoURL { get; set; }

        public int Price { get; set; }
    }
}
