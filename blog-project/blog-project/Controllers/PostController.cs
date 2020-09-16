using blog_data;
using blog_data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog_project.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        [HttpGet]
        public ActionResult Index()
        {
            return View(PostBusiness.GetAllPost());
        }
        [HttpGet]
        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View(PostBusiness.GetPost(id));
        }
        [HttpGet]
        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
                post.Fecha = DateTime.Now;
                if (PostBusiness.AddPost(post))
                {
                    return RedirectToAction("Index");
                }
                return View("~/Post/Create.cshtml", post);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPatch]
        /*
        public ActionResult Update(int id)
        {

            try
            {
                if(PostBusiness.UpdatePost(id))
                {
                    
                }
               
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }
        */

        
    }
}
