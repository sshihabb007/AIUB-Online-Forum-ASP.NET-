using Forum.Data.Interfaces;
using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class PostVoteRepository : Repository<Post_Vote>, IPostVoteRepository
    {
        private DbContext _context;
        public PostVoteRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public int Dislikes(int id)
        {
            return _context.Set<Post_Vote>().Where(x => x.post_id == id && x.vote_status == VoteStatus.Dislike).Count();
        }

        public int Likes(int id)
        {
            return _context.Set<Post_Vote>().Where(x => x.post_id == id && x.vote_status == VoteStatus.Like).Count();
        }

        public int Nones(int id)
        {
            return _context.Set<Post_Vote>().Where(x => x.post_id == id && x.vote_status == VoteStatus.None).Count();
        }

        public VoteStatus MyVoteStatus(int postId, int userId)
        {
            var status = _context.Set<Post_Vote>().Where(x => x.post_id == postId && x.user_id == userId).SingleOrDefault();
            return status == null ? VoteStatus.None : status.vote_status;
        }

        public int AddVote(Post_Vote vote, int userID)
        {
            Post_Vote _vote = _context.Set<Post_Vote>().Where(x => x.post_id == vote.post_id && x.user_id == vote.user_id).SingleOrDefault();
            Ranking rank = _context.Set<Ranking>().Where(x => x.user_id == userID).SingleOrDefault();
            bool flag = _vote == null ? true : false;
            if (flag)
            {
                _context.Set<Post_Vote>().Add(vote);
                rank.points += 1;
                _context.SaveChanges();
                return 1;
            }
            else
            {
                if (_vote.vote_status == VoteStatus.Dislike)
                {
                    _vote.vote_status = VoteStatus.Like;
                    rank.points += 1;
                    _context.SaveChanges();
                    return 2;
                }
                else if (_vote.vote_status == VoteStatus.None)
                {
                    _vote.vote_status = VoteStatus.Like;
                    rank.points += 1;
                    _context.SaveChanges();
                    return 3;
                }
                else if (_vote.vote_status == VoteStatus.Like)
                {
                    _vote.vote_status = VoteStatus.None;
                    rank.points -= 1;
                    _context.SaveChanges();
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int DeleteVote(Post_Vote vote, int userID)
        {
            Post_Vote _vote = _context.Set<Post_Vote>().Where(x => x.post_id == vote.post_id && x.user_id == vote.user_id).SingleOrDefault();
            Ranking rank = _context.Set<Ranking>().Where(x => x.user_id == userID).SingleOrDefault();
            bool flag = _vote == null ? true : false;
            if (flag)
            {
                _context.Set<Post_Vote>().Add(vote);
                rank.points -= 1;
                _context.SaveChanges();
                return 1;
            }
            else
            {
                if (_vote.vote_status == VoteStatus.Like)
                {
                    _vote.vote_status = VoteStatus.Dislike;
                    rank.points -= 1;
                    _context.SaveChanges();
                    return 2;
                }
                else if (_vote.vote_status == VoteStatus.None)
                {
                    _vote.vote_status = VoteStatus.Dislike;
                    rank.points -= 1;
                    _context.SaveChanges();
                    return 3;
                }
                else if (_vote.vote_status == VoteStatus.Dislike)
                {
                    _vote.vote_status = VoteStatus.None;
                    rank.points += 1;
                    _context.SaveChanges();
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
        }
    }
}
