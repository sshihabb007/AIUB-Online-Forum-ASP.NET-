using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Admin.Service.Interface;
using Forum.Entity;

namespace Forum.MVC.UI.MvcAdmin
{
    public class ComplainReplaysModelServices : IComplainReplaysModelService
    {
        private IComplainService _complainService;
        private IComplainReplayService _replayService;
        public ComplainReplaysModelServices(IComplainService complainService,IComplainReplayService replayService)
        {
            _complainService = complainService;
            _replayService = replayService;
        }
        public bool Add(ComplainReplays replay)
        {
            var model = new Complain_Reply();
            model.reply = replay.Body;
            model.complain_id = replay.ComplainId;
            model.user_id = Convert.ToInt32(replay.To);
            return _replayService.Add(model);
            
        }

        public ComplainReplays Preadd(int id)
        {
            var complain = _complainService.SelectById(id);
            ComplainReplays complainReplays = new ComplainReplays();
            complainReplays.ComplainId = complain.complain_id;
            complainReplays.FromUser = complain.from_user;
            complainReplays.ToUser = complain.to_user;
            return complainReplays;
        }
    }
}