using blog_data;
using blog_data.Business;
using PagedList;
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
        public ActionResult Index(int? page)
        {

            ViewData["error"] = TempData["error"];
            //RETURNS A PAGEDLIST, IF IT'S THE FIRST TIME PAGE IS NULL THEN USE A VALUE OF 1,
            //SO DISPLAY THE FIRST PAGE, SECOND VALUE IS THE PAGE SIZE, SO WE WILL HAVE A MAX OF 3 PAGES
            return View(PostBusiness.GetAllPost().ToPagedList(page ?? 1, 5 ));
        }
        [HttpGet]
        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            Post post = PostBusiness.GetPost(id);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                //Response.StatusCode = 404;
                //TempData["error"] = $" ERROR {Response.StatusCode}: ID no encontrada o valida ";
                return HttpNotFound("ID no encontrada o invalida");
            }
            //return RedirectToAction("Index", "Post");
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
                post.IsActive = true;
                if (ModelState.IsValid)
                {
                    //post.Fecha = DateTime.Now;
                    //post.Imagen = "";
                    
                    if (PostBusiness.AddPost(post))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View("~/Views/Post/Create.cshtml", post);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Post");
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Post post = PostBusiness.GetPost(id);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                TempData["error"] = " ERROR: ID no encontrada o valida ";
                return RedirectToAction("Index");
            }
            //return View("~/Views/Post/Update.cshtml", post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.Fecha = DateTime.Now;
                    if (PostBusiness.UpdatePost(post))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = " ERROR: ID no encontrada o valida ";
                        return RedirectToAction("Index");
                    }
                }
                return View(post);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Post post = PostBusiness.GetPost(id);
            if (post != null)
            {
                return View("~/Views/Post/Delete.cshtml", post);
            }
            else
            {
                TempData["error"] = " ERROR: ID no encontrada o valida ";
                return RedirectToAction("Index");
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Post post)
        {
            if (PostBusiness.DeletePost(post))
            {
                return RedirectToAction("Index");
            }
            TempData["error"] = " ERROR: No se pudo eliminar, ID no encontrada o valida ";
            return RedirectToAction("Index");
        }

    }
}
