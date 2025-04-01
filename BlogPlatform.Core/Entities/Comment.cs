using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // العلاقة مع المستخدم (استخدام Id من IdentityUser)
        public string UserId { get; set; }
        public User User { get; set; } = null!;

        // العلاقة مع البوست
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        // العلاقة مع التعليق الأب (للردود)
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
