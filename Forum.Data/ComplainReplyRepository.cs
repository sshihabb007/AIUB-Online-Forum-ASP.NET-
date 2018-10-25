using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ComplainReplyRepository : Repository<Complain_Reply>
    {
        public ComplainReplyRepository(DbContext context) : base(context)
        {
        }
    }
}
