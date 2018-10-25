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
    public class ComplainServices : IComplainService
    {
        private DbContext _context;
        public ComplainServices(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<object> Complite(string search)
        {
            var compalinlist = _context.Set<Complain>().ToList();
            var complitecompalinlist = (from c_lis in compalinlist
                                        where ((c_lis.complain_id.ToString().Contains(search) || c_lis.complain.Contains(search) || c_lis.description.Contains(search)))
                                        select new
                                        {
                                            c_lis.complain_id,
                                            c_lis.complain,
                                            Status = Enum.GetName(typeof(ComplainStatus), c_lis.status)
                                        }).ToList();
            return complitecompalinlist;
        }

        public IEnumerable<Complain> GetAll()
        {
           return _context.Set<Complain>().ToList();
        }

        public bool Reject(int id)
        {
            var model = _context.Set<Complain>().Where(c => c.complain_id == id).SingleOrDefault();
            model.status = ComplainStatus.Rejected;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Complain> Search(string search)
        {
            return _context.Set<Complain>().Where(c => (c.complain_id.ToString().Contains(search) || c.complain.Contains(search) || c.description.Contains(search) )).ToList();
        }

        public Complain SelectById(int Id)
        {
            return _context.Set<Complain>().Find(Id);
        }
    }
}
