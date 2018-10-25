using Forum.Entity;
using Forum.Service;
using Forum.Web.Mvc.Models;
using Forum.MVC.UI.Custon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.MVC.UI.Filter;

namespace Forum.MVC.UI.Controllers
{
    [LoginValidation]
    public class PostController : Controller
    {
        private PostService _postService;
        private UserService _userService;
        private PostCustomServices _service;
        public PostController(PostService postService, UserService userService, PostCustomServices service)
        {
            _postService = postService;
            _userService = userService;
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetAllPost(Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CreatePost = new Post();
            return View(_userService.GetById(Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SinglePost post)
        {
            if (ModelState.IsValid)
            {
                _service.AddPost(post, Convert.ToInt32(Session["userId"].ToString()));
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CreatePost = post;
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_service.GetPostById(id, Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SinglePost post)
        {
            if (ModelState.IsValid)
            {
                _service.EditPost(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_service.GetPostById(id, Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(SinglePost post)
        {
            if(ModelState.IsValid)
            {
                _service.Privacy(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Privacy(int id)
        {
            return View(_service.GetPostById(id, Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Privacy(SinglePost post)
        {
            if(ModelState.IsValid)
            {
                _service.Privacy(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id, Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        public ActionResult LikePost(int postId, int userID)
        {
            return Content(_service.LikeAPost(postId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Like,userID).ToString());
        }

        [HttpPost]
        public ActionResult LikeComment(int commentId, int userID)
        {
            return Content(_service.LikeComment(commentId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Like, userID).ToString());
        }

        [HttpPost]
        public ActionResult LikeReply(int replyId, int userID)
        {
            return Content(_service.LikeReply(replyId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Like, userID).ToString());
        }

        [HttpPost]
        public ActionResult DislikePost(int postId, int userID)
        {
            return Content(_service.DislikeAPost(postId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Dislike, userID).ToString());
        }

        [HttpPost]
        public ActionResult DislikeComment(int commentId, int userID)
        {
            return Content(_service.DislikeComment(commentId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Dislike, userID).ToString());
        }

        [HttpPost]
        public ActionResult DislikeReply(int replyId, int userID)
        {
            return Content(_service.DislikeReply(replyId, Convert.ToInt32(Session["userId"].ToString()), VoteStatus.Like, userID).ToString());
        }

        [HttpPost]
        public ActionResult PostAComment(int postId, string comment)
        {
            return Content(_service.PostAComment(postId, Convert.ToInt32(Session["userId"].ToString()), comment).ToString());
        }

        [HttpPost]
        public ActionResult PostAReply(int commentId, string reply)
        {
            return Content(_service.PostAReply(commentId, Convert.ToInt32(Session["userId"].ToString()), reply).ToString());
        }

        [HttpGet]
        public ActionResult Manage()
        {
            return View(_service.ManagePosts(Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpPost]
        public ActionResult SolvedPost(int postId)
        {
            return View(_service.SolvedPost(postId));
        }

        [HttpPost]
        public ActionResult SolvedComment(int commentId)
        {
            return View(_service.SolvedComment(commentId));
        }

        [HttpGet]
        public ActionResult Ranking()
        {
            return View(_service.Ranking());
        }
    }
}