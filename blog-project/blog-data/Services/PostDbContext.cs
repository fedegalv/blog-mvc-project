using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Services
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> post { get; set; }
    }
}
