using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Admin.Service.Interface;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;

namespace Forum.MVC.UI.MvcAdmin
{
    public class RankingModelServices : IRankingModelService
    {
        private IRankingService _rankingService;
        private IUsersServices _usersServices;
        public RankingModelServices(IRankingService rankingService,IUsersServices usersServices)
        {
            _rankingService = rankingService;
            _usersServices = usersServices;
        }
        public IEnumerable<Rankings> GetAll()
        {
            var model = _rankingService.GetAll();
            var usr = _usersServices.GetAll();
            var rnk = new List<Rankings>();
            foreach(var item in model)
            {
                using (Rankings rankings = new Rankings())
                {
                    rankings.Id = item.ranking_id;
                    rankings.Point = item.points;
                    rankings.UserId = item.user_id;
                    rankings.Name = usr.Where(u => u.user_id == item.user_id).Select(u => u.full_name).SingleOrDefault();
                    rnk.Add(rankings);
                }
            }
            return rnk;
        }
    }
}