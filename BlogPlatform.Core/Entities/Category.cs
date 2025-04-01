using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // العلاقة مع البوستات (Many-to-Many)
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
