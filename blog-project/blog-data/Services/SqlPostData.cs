using System.Collections.Generic;
using System.Linq;

namespace blog_data.Services
{
    public class SqlPostData
    {
        private PostDbContext db;

        public SqlPostData()
        {
            db = new PostDbContext();
        }

        /// <summary>
        /// Add post to the database
        /// </summary>
        /// <param name="post"></param>
        public void Add(Post post)
        {
            db.post.Add(post);
            db.SaveChanges();
        }

        /// <summary>
        /// Get Post from the database, using the Post ID
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns>Returns Post if found, else returns null</returns>
        public Post Get(int id)
        {
            return db.post.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all the Post from the database
        /// </summary>
        /// <returns>IEnumerable with posts</returns>
        public IEnumerable<Post> GetAll()
        {
            return db.post;
        }

        /// <summary>
        /// Remove Post from the database, using the Post ID
        /// </summary>
        /// <param name="id">Post ID</param>
        public void Remove (int id)
        {
            var post = db.post.Find(id);
            var entry = db.Entry(post);
            entry.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        /// <summary>
        /// Update the Post from the database
        /// </summary>
        /// <param name="post">Updated Post</param>
        public void Update(Post post)
        {
            var entry = db.Entry(post);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
