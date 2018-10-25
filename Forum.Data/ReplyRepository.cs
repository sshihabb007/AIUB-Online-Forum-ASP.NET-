using Forum.Data.Interfaces;
using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        private DbContext _context;
        public ReplyRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Reply> GetAllByCommentId(int id)
        {
            return _context.Set<Reply>().Where(x => x.comment_id == id);
        }
    }
}
