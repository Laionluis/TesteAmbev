using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteAmbev.DTOs;
using TesteAmbev.Features.Commands;
using TesteAmbev.Features.Querys;

namespace TesteAmbev.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<SaleDTO>> CreateSale([FromBody] SaleDTO saleDto)
        {
            var result = await _mediator.Send(new CreateSaleCommand(saleDto));
            return CreatedAtAction(nameof(GetSale), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDTO>> GetSale(Guid id)
        {
            var result = await _mediator.Send(new GetSaleQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelSale(Guid id)
        {
            await _mediator.Send(new CancelSaleCommand(id));
            return NoContent();
        }
    }
}
