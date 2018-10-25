using Forum.Data;
using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class ComplainReplyService : Service<Complain_Reply>
    {
        public ComplainReplyService(ComplainReplyRepository repo) : base(repo)
        {
        }
    }
}
