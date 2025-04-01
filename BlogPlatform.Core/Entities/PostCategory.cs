using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.Core.Entities
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
