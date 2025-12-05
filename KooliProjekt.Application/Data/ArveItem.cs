using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class ArveItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LineItem { get; set; }
        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float VatRate { get; set; }

        public float Total { get; set; }

        public ArveList ArveList { get; set; }
        public int ArveListID { get; set; }
    }
}