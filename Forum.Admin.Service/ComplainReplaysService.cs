using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Admin.Service.Interface;
using Forum.Entity;

namespace Forum.Admin.Service
{
    public class ComplainReplaysService : IComplainReplayService
    {
        private DbContext _Context;
        public ComplainReplaysService(DbContext context)
        {
            _Context = context;
        }
        public bool Add(Complain_Reply replay)
        {
            _Context.Set<Complain_Reply>().Add(replay);
            var model = _Context.Set<Complain>().Where(u => u.complain_id== replay.complain_id).SingleOrDefault();
            model.status = ComplainStatus.Approved;
            _Context.SaveChanges();
            return true;
        }

    }
}
