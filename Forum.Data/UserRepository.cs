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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private DbContext _context;
        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public bool EditLastPost(int id)
        {
            var user = _context.Set<User>().Where(x => x.user_id == id).SingleOrDefault();
            user.last_posted = DateTime.Now;
            return _context.SaveChanges() != 0 ? true : false;
        }
    }
}
