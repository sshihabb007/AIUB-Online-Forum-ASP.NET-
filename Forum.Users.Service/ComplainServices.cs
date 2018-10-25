using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Users.Service.Interface;
using Forum.Entity;
using System.Data.Entity;
namespace Forum.Users.Service
{
    public class ComplainServices : IComplainServices
    {
        private DbContext _context;
        public ComplainServices(DbContext context)
        {
            _context = context;
        }
        public bool AddComplain(Complain com)
        {
            var user = _context.Set<Complain>().ToList();
            user.Add(com);
            _context.SaveChanges();
            return true;
    }

        public IEnumerable<Complain> ComplainListByUser(int Id)
        {
            return _context.Set<Complain>().Where(u => u.from_user == Id).ToList();
        }
    }
}
