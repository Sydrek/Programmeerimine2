using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// 14.11.2025
    /// Testandmete generaator
    /// 
    /// Testandmed genereeritakse ainult siis kui mõni oluline 
    /// tabel on tühi.
    /// </summary>
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Genereerib andmed
        /// </summary>
        public void Generate()
        {

            Random rnd = new Random();

            //if (_dbContext.Arved.Any())
            //{
            //    return;
            //}

            for (var i = 0; i < 10; i++)
            {
                var list = new ArveList { LineItem = "List " + (i + 1) };
                _dbContext.Arved.Add(list);

                for (var j = 0; j < 1; j++)
                {
                    var item = new ArveItem
                    {
                        LineItem = "Item " + (i + 1) + "." + (j + 1),
                        UnitPrice = rnd.Next(1, 100),
                        Quantity = rnd.Next(1, 10),
                        VatRate = rnd.Next(5, 25),
                        Total = rnd.Next(1, 100),
                        ArveList = list
                    };
                    _dbContext.ArveItems.Add(item);
                }
            }

            //if (_dbContext.Kliendid.Any())
            //{
            //    return;
            //}

            for (var i = 0; i < 10; i++)
            {
                var list = new KlientList { Name = "List " + (i + 1) };
                _dbContext.Kliendid.Add(list);

                for (var j = 0; j < 1; j++)
                {
                    var item = new KlientItem
                    {
                        Name = "Item " + (i + 1) + "." + (j + 1),
                        Address = "Address " + (i + 1) + "." + (j + 1),
                        Email = "Email " + (i + 1) + "." + (j + 1),
                        Phone = rnd.Next(5, 25).ToString(),
                        Discount = rnd.Next(1, 100),
                        KlientList = list
                    };
                    _dbContext.KlientItems.Add(item);
                }
            }

            //if (_dbContext.Tellimused.Any())
            //{
            //    return;
            //}

            for (var i = 0; i < 10; i++)
            {
                var list = new TellimusList { InvoiceNumber = "List " + (i + 1) };
                _dbContext.Tellimused.Add(list);

                for (var j = 0; j < 1; j++)
                {
                    var item = new TellimusItem
                    {
                        InvoiceNumber = "Item " + (i + 1) + "." + (j + 1),
                        InvoiceDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        Status = "Status " + (i + 1) + "." + (j + 1),
                        SubTotal = rnd.Next(1, 100),
                        ShippingTotal = rnd.Next(1, 100),
                        Discount = rnd.Next(1, 100),
                        GrandTotal = rnd.Next(1, 100),
                        TellimusList = list
                    };
                    _dbContext.TellimusItems.Add(item);
                }
            }

            //if (_dbContext.Tooted.Any())
            //{
            //    return;
            //}

            for (var i = 0; i < 10; i++)
            {
                var list = new ToodeList { Name = "List " + (i + 1) };
                _dbContext.Tooted.Add(list);

                for (var j = 0; j < 1; j++)
                {
                    var item = new ToodeItem
                    {
                        Name = "Item " + (i + 1) + "." + (j + 1),
                        Description = "Desc. " + (i + 1) + "." + (j + 1),
                        FotoURL = "URL " + (i + 1) + "." + (j + 1),
                        Price = rnd.Next(5, 25),
                        ToodeList = list
                    };
                    _dbContext.ToodeItems.Add(item);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
