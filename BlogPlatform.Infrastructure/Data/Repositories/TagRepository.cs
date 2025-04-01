using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastructure.Data.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag>> GetTagsWithPostsAsync()
        {
            return await _context.Tags
                .Include(t => t.PostTags)
                    .ThenInclude(pt => pt.Post)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            return await _context.Tags
                .Include(t => t.PostTags)
                    .ThenInclude(pt => pt.Post)
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());
        }
    }
} 