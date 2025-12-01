using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Arved;
using KooliProjekt.Application.Features.Kliendid;
using KooliProjekt.Application.Features.Tellimused;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class TellimusController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TellimusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListTellimusQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTellimusQuery { Id = id };
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SaveTellimusCommand command)
        {
            var response = await _mediator.Send(command);

            return Result(response);
        }
    }
}
