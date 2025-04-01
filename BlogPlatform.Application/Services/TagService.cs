using BlogPlatform.Core.Entities;
using BlogPlatform.Core.InterFaces.IRepository;
using BlogPlatform.Application.Interfaces;

namespace BlogPlatform.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _unitOfWork.Tags.GetAllAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _unitOfWork.Tags.GetByIdAsync(id);
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            await _unitOfWork.Tags.AddAsync(tag);
            await _unitOfWork.SaveChangesAsync();
            return tag;
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            _unitOfWork.Tags.Update(tag);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(int id)
        {
            var tag = await _unitOfWork.Tags.GetByIdAsync(id);
            if (tag != null)
            {
                _unitOfWork.Tags.Remove(tag);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
} 