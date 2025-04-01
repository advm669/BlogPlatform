using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // العلاقة مع البوستات (Many-to-Many)
        public ICollection<PostTag> PostTags { get; set; }
    }
}
