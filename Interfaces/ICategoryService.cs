using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Models;

namespace SpotifyMVC.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(CreateCategoryRequest createCategoryRequest);
    Task<bool> RemoveCategoryAsync(int id);
}
