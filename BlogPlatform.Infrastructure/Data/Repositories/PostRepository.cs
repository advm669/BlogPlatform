using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastructure.Data.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetPostsWithCommentsAsync()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .Where(p => p.PostCategories.Any(pc => pc.CategoryId == categoryId))
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(int tagId)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.PostTags)
                    .ThenInclude(pt => pt.Tag)
                .Where(p => p.PostTags.Any(pt => pt.TagId == tagId))
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
} 