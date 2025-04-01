using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using BlogPlatform.Application.Interfaces;

namespace BlogPlatform.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPostsWithCommentsAsync()
        {
            return await _unitOfWork.Posts.GetPostsWithCommentsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _unitOfWork.Posts.GetByIdAsync(id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _unitOfWork.Posts.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
            return post;
        }

        public async Task UpdatePostAsync(Post post)
        {
            _unitOfWork.Posts.Update(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post != null)
            {
                _unitOfWork.Posts.Remove(post);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await _unitOfWork.Posts.GetPostsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(int tagId)
        {
            return await _unitOfWork.Posts.GetPostsByTagAsync(tagId);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId)
        {
            return await _unitOfWork.Posts.GetPostsByUserIdAsync(userId);
        }
    }
} 