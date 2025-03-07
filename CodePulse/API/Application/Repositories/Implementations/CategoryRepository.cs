using Application.Data;
using Application.Models.Domain;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await context.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await context.Categories.ToListAsync(); 
        }

        public async Task<Category?> GetCategoryById(Guid Id)
        {
            return await context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Category?> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory != null)
            {
                context.Entry(existingCategory).CurrentValues.SetValues(category);
                await context.SaveChangesAsync();
                return existingCategory;
            }

            return null;
        }
    }
}
