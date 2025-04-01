using BlogPlatform.Core.Entities;

namespace BlogPlatform.Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsWithCommentsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId);
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(int categoryId);
        Task<IEnumerable<Post>> GetPostsByTagAsync(int tagId);
        Task<Post> CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
} 