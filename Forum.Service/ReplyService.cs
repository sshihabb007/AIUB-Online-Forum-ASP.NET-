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
    public class ReplyService : Service<Reply>, IReplyService
    {
        ReplyRepository _repo;
        public ReplyService(ReplyRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public int DislikeCount(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> GetAllByCommentId(int id)
        {
            return _repo.GetAllByCommentId(id);
        }

        public int LikeCount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
