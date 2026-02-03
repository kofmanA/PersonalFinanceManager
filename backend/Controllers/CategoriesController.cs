using AutoMapper;
using backend.Data;
using backend.DTOs.CategoryDtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoriesController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
    }

    // GET: api/categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        return Ok(_mapper.Map<CategoryDto>(category));
    }

    // POST: api/categories
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        var result = _mapper.Map<CategoryDto>(category);

        return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, result);
    }

    // PUT: api/categories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CreateCategoryDto dto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        _mapper.Map(dto, category);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
