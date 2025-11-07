using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data
{

    public class Arve
    {
        public int ID { get; set; }

        public string LineItem { get; set; }

        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float VatRate { get; set; }

        public float Total { get; set; }
    }
}
