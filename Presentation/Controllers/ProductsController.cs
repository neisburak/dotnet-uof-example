using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetAsync(id, cancellationToken);
        return Ok(product);
    }

    [HttpGet("{page}/{pageCount}")]
    public async Task<IActionResult> GetAsync(int page, int pageCount, CancellationToken cancellationToken)
    {
        return Ok(await _productService.GetAsync(page, pageCount, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Product product, CancellationToken cancellationToken)
    {
        await _productService.AddAsync(product, cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] Product product, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(product, cancellationToken);
        return Ok();
    }
}