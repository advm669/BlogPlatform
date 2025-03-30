using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogPlatform.Core.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }=null!;
        public string LastName { get; set; } = null!;

        // 
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
