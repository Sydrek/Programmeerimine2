using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Tellimused;
using KooliProjekt.Application.Features.Tooted;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ToodeController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ToodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListToodeQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
