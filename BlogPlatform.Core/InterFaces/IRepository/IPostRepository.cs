using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPlatform.Core.Entities;

namespace BlogPlatform.Core.InterFaces.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsWithCommentsAsync();
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId);
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(int categoryId);
        Task<IEnumerable<Post>> GetPostsByTagAsync(int tagId);
    }
}
