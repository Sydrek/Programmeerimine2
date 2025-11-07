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
    public class KlientController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<KlientController> _logger;

        public KlientController(ILogger<KlientController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetKlient")]
        public IEnumerable<Klient> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Klient
            {
                ID = index,
                Name = "Test",
                Address = Summaries[Random.Shared.Next(Summaries.Length)],
                Email = "klient@gmail.com",
                Phone = "553321",
                Discount = 5.5f
            })
            .ToArray();
        }
    }
}
