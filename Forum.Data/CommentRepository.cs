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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private DbContext _context;
        public CommentRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public int CommentCount(int id)
        {
            return _context.Set<Comment>().Where(x => x.post_id == id).Count();
        }

        public IEnumerable<Comment> GetAllByPostId(int id)
        {
            return _context.Set<Comment>().Where(x => x.post_id == id);
        }
    }
}
