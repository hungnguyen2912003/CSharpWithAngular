using Application.Models.Domain;

namespace Application.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);

        Task<IEnumerable<Category>> GetAllCategoryAsync();

        Task<Category?> GetCategoryById(Guid Id);

        Task<Category?> UpdateCategoryAsync(Category category);
    }
}
