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
    public class CommentVoteService : Service<Comment_Vote>, ICommentVoteService
    {
        private CommentVoteRepository _repo;
        public CommentVoteService(CommentVoteRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public VoteStatus MyVoteStatus(int id, int userId)
        {
            return _repo.MyVoteStatus(id, userId);
        }

        public int DislikeCount(int id)
        {
            return _repo.Dislikes(id);
        }

        public int LikeCount(int id)
        {
            return _repo.Likes(id);
        }

        public int AddVote(Comment_Vote vote, int userID)
        {
            return _repo.AddVote(vote, userID);
        }

        public int DeleteVote(Comment_Vote vote, int userID)
        {
            return _repo.DeleteVote(vote, userID);
        }
    }
}
