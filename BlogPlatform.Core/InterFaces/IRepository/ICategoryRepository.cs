using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPlatform.Core.Entities;

namespace BlogPlatform.Core.InterFaces.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithPostsAsync();
        Task<Category> GetCategoryByNameAsync(string name);
    }
}
