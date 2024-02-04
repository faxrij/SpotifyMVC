using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SpotifyMVC.Data;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories. 
            Include(c => c.ParentCategory)
            .Include(c => c.Songs)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    public async Task<Category> CreateCategoryAsync(CreateCategoryRequest createCategoryRequest)
    {
        Category category = new Category();
        var parentCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == createCategoryRequest.ParentCategoryId);
        
        if (parentCategory == null)
        {
            throw new InvalidOperationException($"Parent category with ID {createCategoryRequest.ParentCategoryId} not found.");
        }

        category.isParentCategory = false;
        category.Songs = new List<Song>();
        category.Name = createCategoryRequest.Name;
        
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> RemoveCategoryAsync(int id)
    {
        var categoryToRemove = await _context.Categories.FindAsync(id);

        if (categoryToRemove == null)
        {
            return false;
        }

        _context.Categories.Remove(categoryToRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}
