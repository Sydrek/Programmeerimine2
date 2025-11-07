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
    public class ArveController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Odav Arve", "Kallis Arve", "Normaalne Arve", "Tasuta Arve", "Kergelt kallis Arve", "Tavaline Arve", "Poe Arve", "Soe Arve", "Kuum Arve", "Kõrvetav Arve"
        };

        private readonly ILogger<ArveController> _logger;

        public ArveController(ILogger<ArveController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetArve")]
        public IEnumerable<Arve> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Arve
            {
                ID = index,
                LineItem = "Test",
                UnitPrice = 67f,
                Quantity = 3,
                VatRate = 21f,
                Total = 200f
            })
            .ToArray();
        }
    }
}
