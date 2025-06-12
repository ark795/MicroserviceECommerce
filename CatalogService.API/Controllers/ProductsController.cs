using CatalogService.API.Application.Commands;
using CatalogService.API.Application.Queries;
using CatalogService.API.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    // POST api/products
    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // PUT api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch.");

        var updated = await _mediator.Send(command);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    // DELETE api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteProductCommand { Id = id });
        if (!success) return NotFound();

        return NoContent();
    }
}
