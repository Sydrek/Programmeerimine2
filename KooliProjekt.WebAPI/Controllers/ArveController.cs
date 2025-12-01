using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Arved;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ArveController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ArveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListArveQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
