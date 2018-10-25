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
    public class UserService : Service<User>, IUserService
    {
        private UserRepository _repo;
        public UserService(UserRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public bool EditLastPost(int id)
        {
            return _repo.EditLastPost(id);
        }
    }
}
