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
    public class PostVoteService : Service<Post_Vote>, IPostVoteService
    {
        private PostVoteRepository _repo;
        public PostVoteService(PostVoteRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public int DislikeCount(int id)
        {
            return _repo.Dislikes(id);
        }

        public int LikeCount(int id)
        {
            return _repo.Likes(id);
        }

        public int NoneCount(int id)
        {
            return _repo.Nones(id);
        }

        public VoteStatus MyVoteStatus(int postId,int userId)
        {
            return _repo.MyVoteStatus(postId,userId);
        }

        public int AddVote(Post_Vote vote, int userID)
        {
            return _repo.AddVote(vote, userID);
        }

        public int DeleteVote(Post_Vote vote, int userID)
        {
            return _repo.DeleteVote(vote, userID);
        }
    }
}
