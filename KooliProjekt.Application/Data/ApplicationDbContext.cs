using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ArveList> Arved { get; set; }
        public DbSet<ArveItem> ArveItems { get; set; }
        public DbSet<KlientList> Kliendid { get; set; }
        public DbSet<KlientItem> KlientItems { get; set; }
        public DbSet<TellimusList> Tellimused { get; set; }
        public DbSet<TellimusItem> TellimusItems { get; set; }
        public DbSet<ToodeList> Tooted { get; set; }
        public DbSet<ToodeItem> ToodeItems { get; set; }
    }
}
 