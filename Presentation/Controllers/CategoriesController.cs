using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        var product = await _categoryService.GetAsync(id, cancellationToken);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Category category, CancellationToken cancellationToken)
    {
        await _categoryService.AddAsync(category, cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] Category category, CancellationToken cancellationToken)
    {
        await _categoryService.UpdateAsync(category, cancellationToken);
        return Ok();
    }
}