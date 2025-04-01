using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using BlogPlatform.Application.Interfaces;

namespace BlogPlatform.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _unitOfWork.Comments.GetAllAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _unitOfWork.Comments.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _unitOfWork.Comments.GetCommentsByPostIdAsync(postId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            return await _unitOfWork.Comments.GetCommentsByUserIdAsync(userId);
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return comment;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _unitOfWork.Comments.Update(comment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _unitOfWork.Comments.GetByIdAsync(id);
            if (comment != null)
            {
                _unitOfWork.Comments.Remove(comment);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comment>> GetRepliesAsync(int commentId)
        {
            return await _unitOfWork.Comments.GetRepliesAsync(commentId);
        }
    }
} 