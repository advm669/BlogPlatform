using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithPostsAsync()
        {
            return await _context.Categories
                .Include(c => c.PostCategories)
                    .ThenInclude(pc => pc.Post)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories
                .Include(c => c.PostCategories)
                    .ThenInclude(pc => pc.Post)
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
} 