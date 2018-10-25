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
    public class CommentService : Service<Comment>, ICommentService
    {
        private CommentRepository _repo;
        public CommentService(CommentRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public int CommentCount(int id)
        {
            return _repo.CommentCount(id);
        }

        public IEnumerable<Comment> GetAllByPostId(int id)
        {
            return _repo.GetAllByPostId(id);
        }
    }
}
