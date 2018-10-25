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
   public class Change_Info_RequestService: IChangeInfoRequestService
    {
        private readonly DbContext _context;
        public Change_Info_RequestService(DbContext context)
        {
            _context = context;
        }

        public bool ApproveById(int Id)
        {
                var cirlst = _context.Set<Change_Info_Request>().Where(cr1 => cr1.request_id == Id).SingleOrDefault();
                cirlst.status = RequestStatus.Approved;
                _context.SaveChanges();
                return true;
        }

        public IEnumerable<Change_Info_Request> GetAllList()
        {
            return _context.Set<Change_Info_Request>().ToList();
        }

        public bool RejectById(int Id)
        {
            var cirlst = _context.Set<Change_Info_Request>().Where(cr1 => cr1.request_id == Id).SingleOrDefault();
            cirlst.status = RequestStatus.Rejected;
            _context.SaveChanges();
            return true;
        }

        public Change_Info_Request SelectById(int id)
        {
            return _context.Set<Change_Info_Request>().Find(id);
        }
    }
}
