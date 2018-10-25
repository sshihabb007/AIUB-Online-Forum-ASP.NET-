using Forum.Data;
using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class ComplainService : Service<Complain>, IComplainService
    {
        private ComplainRepository _repo;
        public ComplainService(ComplainRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public IEnumerable<Complain> GetAllAboutMe(int id)
        {
            return _repo.GetAllAboutMe(id);
        }

        public IEnumerable<Complain> GetAllFromMe(int id)
        {
            return _repo.GetAllFromMe(id);
        }
    }
}
