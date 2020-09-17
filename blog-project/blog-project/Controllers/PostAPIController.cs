﻿using blog_data;
using blog_data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace blog_project.Controllers
{
    [RoutePrefix("api")]
    public class PostAPIController : ApiController
    {
        [HttpGet]
        [Route("posts")]
        public List<Post> GetAllPosts()
        {

            return PostBusiness.GetAllPost().ToList();
        }
        [HttpGet]
        [Route("posts/{id}")]
        public Post GetPost(int id)
        {
            return PostBusiness.GetPost(id);
        }

        //[HttpPost]
        //[Route("posts")]
        //public bool AddPost(Post post)
        //{

        //}
    }
}
