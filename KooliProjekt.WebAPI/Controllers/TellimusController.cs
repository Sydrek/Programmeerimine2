using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KooliProjekt.Application.Data;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TellimusController : ControllerBase
    {
        public DateTime today = DateTime.Today;
        public int i = 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TellimusController> _logger;

        public TellimusController(ILogger<TellimusController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTellimus")]
        public IEnumerable<Tellimus> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Tellimus
            {
                ID = index,
                InvoiceNumber = 5,
                InvoiceDate = today,
                DueDate = today.AddDays(3),
                Status = "Shipping",
                SubTotal = 10f,
                ShippingTotal = 10f,
                Discount = 10f,
                GrandTotal = 10f
            })
            .ToArray();
        }
    }
}
