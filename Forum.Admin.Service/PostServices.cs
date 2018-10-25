using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Admin.Service.Interface;
using System.Data.Entity;
using Forum.Entity;

namespace Forum.Admin.Service
{
    public class PostServices : IPostServices
    {
        private DbContext _context;
        public PostServices(DbContext context)
        {
            _context = context;
        }
        public bool Delete(int Id)
        {
            var post = _context.Set<Post>().Find(Id);
            _context.Set<Post>().Remove(post);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Set<Post>().ToList();
        }

        public IEnumerable<Post> GetListByUser(string Id)
        {
            return _context.Set<Post>().Where(p => p.user_id == Convert.ToInt32(Id)).ToList();
        }

        public IEnumerable<Post> Search(string search)
        {
           return _context.Set<Post>().Where(p => p.title.Contains(search) || p.body.ToString().Contains(search)).ToList();
        }

        public Post SelectById(int Id)
        {
            return _context.Set<Post>().Find(Id);
        }
    }
}
