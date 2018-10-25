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
    public class ReplyVoteService : Service<Reply_Vote>, IReplyVoteService
    {
        private ReplyVoteRepository _repo;
        public ReplyVoteService(ReplyVoteRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public int AddVote(Reply_Vote vote, int userID)
        {
            return _repo.AddVote(vote, userID);
        }

        public int DeleteVote(Reply_Vote vote, int userID)
        {
            return _repo.DeleteVote(vote, userID);
        }

        public int Dislikes(int id)
        {
            return _repo.Dislikes(id);
        }

        public int Likes(int id)
        {
            return _repo.Likes(id);
        }

        public VoteStatus MyVoteStatus(int id, int userId)
        {
            return _repo.MyVoteStatus(id,userId);
        }
    }
}
