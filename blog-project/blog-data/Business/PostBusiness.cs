using blog_data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_data.Business
{
    /// <summary>
    /// Class in charge of validating Post before calling SQL Services
    /// </summary>
    public class PostBusiness
    {
        /// <summary>
        /// Validates post according to its own data annotations.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        static public bool ValidatePost(Post post)
        {
            bool validationStatus = false;
            var validationContext = new ValidationContext(post);
            var validationResults = new List<ValidationResult>();
            // Validates post according to its own data annotations. Returns true if valid, false if not
            if (Validator.TryValidateObject(post, validationContext, validationResults, false))
            {
                validationStatus = true;
            }
            return validationStatus;
        }

        /// <summary>
        /// Adds a validated post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Return true if add is successfull, else return false</returns>
        static public bool AddPost(Post post)
        {
            bool operationSuccess = false;
            if (post != null && ValidatePost(post))
            {
                //ASIGNAMOS FECHA
                post.Fecha = DateTime.Now;
                //post.Imagen = "";
                //post.Categoria = "";
                SqlPostData sql = new SqlPostData();
                sql.Add(post);
                operationSuccess = true;
            }
            return operationSuccess;
        }

        /// <summary>
        /// Gets a post
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return post if found, else null</returns>
        static public Post GetPost(int id)
        {
            SqlPostData sql = new SqlPostData();
            return sql.Get(id);
        }
        /// <summary>
        /// Gets all the posts
        /// </summary>
        /// <returns>IEnumerable of Post</returns>
        static public IEnumerable<Post> GetAllPost()
        {
            SqlPostData sql = new SqlPostData();
            return sql.GetAll().OrderByDescending(x => x.Fecha);
        }

        /// <summary>
        /// Updates post, using the id
        /// </summary>
        /// <param name="id">Id of the Post to update</param>
        /// <returns>Return true if update is successfull, else return false </returns>
        static public bool UpdatePost(Post post)
        {
            bool operationSuccess = false;
            if (post != null && ValidatePost(post))
            {
                SqlPostData sql = new SqlPostData();
                sql.Update(post);
                operationSuccess = true;
            }
            return operationSuccess;
        }
        /// <summary>
        /// Deletes post
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if sucessfull, else returns false</returns>
        static public bool DeletePost(Post post)
        {
            bool operationSucess = false;
            if (post != null)
            {
                SqlPostData sql = new SqlPostData();
                sql.Remove(post.Id);
                operationSucess = true;
            }
            return operationSucess;
        }
    }
}
