using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Admin.Service.Interface;

namespace Forum.MVC.UI.MvcAdmin
{
    public class Starustic : IStarustic
    {
        private IUsersServices _usersServices;
        private IPostServices _postServices;
        private IComplainService _complainService;
        public Starustic(IUsersServices usersServices,IPostServices postServices,IComplainService complainService)
        {
            _usersServices = usersServices;
            _postServices = postServices;
            _complainService = complainService;
        }
        public Statistics GetInfo()
        {
            var student = _usersServices.GetAllStudent();
            var moderator = _usersServices.GetAllModerator();
            var post = _postServices.GetAll();
            var complain = _complainService.GetAll();
            return new Statistics()
            {
                Student = student.Count(),
                Moderator = moderator.Count(),
                Solved = post.Where(p => p.status == Entity.PostStatus.Solved).Count(),
                Unsolved = post.Where(p => p.status == Entity.PostStatus.Unsolved).Count(),
                Complain=complain.Where(c=>c.status==Entity.ComplainStatus.Pending).Count(),
                Actioned=complain.Where(c=>c.status!=Entity.ComplainStatus.Pending).Count()
            };
        }
    }
}