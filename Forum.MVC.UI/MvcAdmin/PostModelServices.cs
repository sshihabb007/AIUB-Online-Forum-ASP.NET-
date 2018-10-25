using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Admin.Service.Interface;

namespace Forum.MVC.UI.MvcAdmin
{
    public class PostModelServices : IPostModelServices
    {
        private IPostServices _postServices;
        public PostModelServices(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public bool Delete(int Id)
        {
            _postServices.Delete(Id);
            return true;
        }

        public IEnumerable<Posts> GetAll()
        {
            var model = _postServices.GetAll();
            var lst = new List<Posts>();
            foreach(var item in model)
            {
                using (Posts post = new Posts())
                {
                    post.Activity = item.activity;
                    post.Body = new HtmlString(item.body);
                    post.Id = item.post_id;
                    post.Status = item.status;
                    post.Title = item.title;
                    post.UserId = item.user_id;
                    lst.Add(post);
                }
            }
            return lst;
        }

        public IEnumerable<Posts> GetListByUser(string Id)
        {
            var model = _postServices.GetListByUser(Id);
            var lst = new List<Posts>();
            foreach(var item in model)
            {
                using (Posts post = new Posts())
                {
                    post.Activity = item.activity;
                    post.Body = new HtmlString(item.body);
                    post.Id = item.post_id;
                    post.Status = item.status;
                    post.Title = item.title;
                    post.UserId = item.user_id;
                    lst.Add(post);
                }
            }
            return lst;
        }

        public IEnumerable<Posts> Search(string search)
        {
            var model = _postServices.Search(search);
            var lst = new List<Posts>();
            foreach(var item in model)
            {
                using (Posts post = new Posts())
                {
                    post.Activity = item.activity;
                    post.Body = new HtmlString(item.body);
                    post.Id = item.post_id;
                    post.Status = item.status;
                    post.Title = item.title;
                    post.UserId = item.user_id;
                    lst.Add(post);
                }
            }
            return lst;
        }

        public Posts SelectById(int Id)
        {
            var model = _postServices.SelectById(Id);
            var post = new Posts();
            post.Activity = model.activity;
            post.Body = new HtmlString(model.body);
            post.Id = model.user_id;
            post.Status = model.status;
            post.Title = model.title;
            post.UserId = model.user_id;
            return post;
        }
    }
}