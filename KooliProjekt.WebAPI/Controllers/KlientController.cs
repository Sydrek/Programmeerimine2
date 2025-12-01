using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Arved;
using KooliProjekt.Application.Features.Kliendid;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class KlientController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public KlientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListKlientQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
