using Blog.Models;
using Blog.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostOperetionsController : Controller
    {
        BlogContext db = new BlogContext();

        // GET: PostOperetions
        public string PostPriorityUpdate(int postId, int priority)
        {
            var foundPost = db.Posts.FirstOrDefault(post => post.Id == postId);
            foundPost.Priority =(Priority)priority;
            db.SaveChanges();
            return "Updated";
        }

        /// <summary>
        /// method for create new post
        /// </summary>
        /// <param name="PostTitle"></param>
        /// <param name="PostText"></param>
        /// <param name="ImageUrl"></param>
        /// <param name="Priority"></param>
        public ActionResult InsertPost(string PostTitle, string PostText, string ImageUrl, int Priority)
        {
            //create post in memory
            Post newPost = new Post();
            newPost.PostText = PostText;
            newPost.ImageUrl = ImageUrl;
            newPost.Priority = (Priority)Priority;
            newPost.DateCreated= DateTime.Now;

            //add to dbSet
            db.Posts.Add(newPost);
            //insert in db 
            db.SaveChanges();

            return View();
        }

        /// <summary>
        /// method for delete post by id 
        /// </summary>
        /// <param name="id">post id</param>
        public ActionResult DeletePost(int id)
        {
            var foundPost = db.Posts.FirstOrDefault(post => post.Id == id);

            if (foundPost == null)
            {
                var model = new ActionResultModel()
                {
                    Message = "Ошибка при удалении поста"
                };

                return View("ActionResultView", model);
            }

            db.Posts.Remove(foundPost);
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult AddComment(long postId, string commentText)
        {
            try
            {
                //проверка на мат если есть, то заменять матерное слово звёздочками и соханять коммент в бд
                ModerationUtil.Verify(db, postId, commentText);
                return Redirect("/Home/Index");
            }
            catch (Exception)
            {
                var model = new ActionResultModel()
                {
                    Message = "Ошибка при добавлении коммента"
                };

                return View("ActionResultView", model);

            }
        }

      

        public ActionResult DeleteComment(long commentId)
        {
            var foundComment = db.Comments.FirstOrDefault(c => c.Id == commentId);

            if(foundComment == null)
            {
                var model = new ActionResultModel()
                {
                    Message = "Ошибка при удалении коммента"
                };

                return View("ActionResultView", model);
            }

            db.Comments.Remove(foundComment);
            db.SaveChanges();

            return Redirect("/Home/Index");
        }
    }
}