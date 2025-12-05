using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Arved;
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
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ListToodeQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetToodeQuery { ID = id };
            var response = await _mediator.Send(query);

            return Result(response);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(SaveToodeCommand command)
        {
            var response = await _mediator.Send(command);

            return Result(response);
        }

        // 14.11.2025
        // Delete meetod listi kustutamiseks
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteToodeCommand command)
        {
            var response = await _mediator.Send(command);

            return Result(response);
        }
    }
}
