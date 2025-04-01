using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPlatform.Core.Entities;

namespace BlogPlatform.Core.InterFaces.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetTagsWithPostsAsync();
        Task<Tag> GetTagByNameAsync(string name);
    }
}
