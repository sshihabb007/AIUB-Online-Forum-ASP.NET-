using Forum.Data.Interfaces;
using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ReplyVoteRepository : Repository<Reply_Vote>, IReplyVoteRepository
    {
        private DbContext _context;
        public ReplyVoteRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public int Likes(int id)
        {
            return _context.Set<Reply_Vote>().Where(x => x.reply_id == id && x.vote_status == VoteStatus.Like).Count();
        }

        public int Dislikes(int id)
        {
            return _context.Set<Reply_Vote>().Where(x => x.reply_id == id && x.vote_status == VoteStatus.Dislike).Count();
        }

        public VoteStatus MyVoteStatus(int id, int userId)
        {
            var status = _context.Set<Reply_Vote>().Where(x => x.reply_id == id && x.user_id == userId).SingleOrDefault();
            return status == null ? VoteStatus.None : status.vote_status;
        }

        public int AddVote(Reply_Vote vote, int userID)
        {
            Reply_Vote _vote = _context.Set<Reply_Vote>().Where(x => x.reply_id == vote.reply_id && x.user_id == vote.user_id).SingleOrDefault();
            Ranking rank = _context.Set<Ranking>().Where(x => x.user_id == userID).SingleOrDefault();
            bool flag = _vote == null ? true : false;
            if (flag)
            {
                _context.Set<Reply_Vote>().Add(vote);
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

        public int DeleteVote(Reply_Vote vote, int userID)
        {
            Reply_Vote _vote = _context.Set<Reply_Vote>().Where(x => x.reply_id == vote.reply_id && x.user_id == vote.user_id).SingleOrDefault();
            Ranking rank = _context.Set<Ranking>().Where(x => x.user_id == userID).SingleOrDefault();
            bool flag = _vote == null ? true : false;
            if (flag)
            {
                _context.Set<Reply_Vote>().Add(vote);
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
