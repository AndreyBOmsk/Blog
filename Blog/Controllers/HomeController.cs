using Blog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext db;

        public HomeController()
        {
            db = new BlogContext(); 
        }

        public ActionResult Index()
        {
            var result = db.Posts.Include("Comments").ToList();
            return View(result);
        }

        private static List<Post> SortMethod(List<Post> result)
        {
            List<Post> SortedResult = new List<Post>();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Priority == Priority.Hight)
                {
                    SortedResult.Add(result[i]);
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Priority == Priority.Midle)
                {
                    SortedResult.Add(result[i]);
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Priority == Priority.Low)
                {
                    SortedResult.Add(result[i]);
                }
            }

            return SortedResult;
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult DeletePost()
        {
            return View();
        }
    }
}