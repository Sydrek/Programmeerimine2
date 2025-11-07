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

    public class ToodeController : ControllerBase
    {
        public int i = 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ToodeController> _logger;

        public ToodeController(ILogger<ToodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetToode")]
        public IEnumerable<Toode> Get()
        {

            return Enumerable.Range(1, 5).Select(index => new Toode
            {
                ID = index,
                Name = "Test",
                Description = Summaries[Random.Shared.Next(Summaries.Length)],
                FotoURL = "https://google.com",
                Price = 10
            })
            .ToArray();
        }
    }
}
