using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(CreateCategoryRequest createCategoryRequest)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryRequest);
        return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.CategoryId }, createdCategory);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result = await _categoryService.RemoveCategoryAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}