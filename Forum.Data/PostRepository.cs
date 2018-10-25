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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private DbContext _context;
        public PostRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public bool DeletePost(int id)
        {
            var data = _context.Set<Post>();
            var post = _context.Set<Post>().Where(x=> x.post_id==id).SingleOrDefault();
            /*
             var allComments = _context.Set<Comment>();
            var comments = _context.Set<Comment>().Where(x=> x.post_id==id);
            foreach (var comment in comments)
            {
                var allReplies = _context.Set<Reply>();
                var replies = _context.Set<Reply>().Where(x => x.comment_id == comment.comment_id);
                foreach (var reply in replies)
                {
                    var allReplyVotes = _context.Set<Reply_Vote>();
                    var replyVote = _context.Set<Reply_Vote>().Where(x => x.reply_id == reply.reply_id);
                    foreach (var vote in replyVote)
                    {
                        allReplyVotes.Remove(vote);
                    }
                    allReplies.Remove(reply);
                }
                var allCommentVotes = _context.Set<Comment_Vote>();
                var commentVote = _context.Set<Comment_Vote>().Where(x => x.comment_id == comment.comment_id);
                foreach (var vote in commentVote)
                {
                    allCommentVotes.Remove(vote);
                }
                allComments.Remove(comment);
            }
             */
            data.Remove(post);
            _context.SaveChanges();
            return true;

        }

        public bool EditPost(Post post)
        {
            var data = _context.Set<Post>().Where(x => x.post_id == post.post_id).SingleOrDefault();
            data.title = post.title;
            data.body = post.body;
            data.tags = post.tags;
            _context.SaveChanges();
            return true;
        }

        public bool HidePost(Post post)
        {
            var data = _context.Set<Post>().Where(x => x.post_id == post.post_id).SingleOrDefault();
            if (data.activity == PostActivity.Active)
            {
                data.activity = PostActivity.Inactive;
                _context.SaveChanges();
            }
            else
            {
                data.activity = PostActivity.Active;
                _context.SaveChanges();
            }
            return true;
        }

        public IEnumerable<Post> GetAllByPostsId(int id)
        {
            return _context.Set<Post>().Where(x=> x.user_id==id);
        }

        public bool SolvedPost(int postId)
        {
            var post = _context.Set<Post>().Where(x=> x.post_id==postId).SingleOrDefault();
            post.status = PostStatus.Solved;
            return _context.SaveChanges() != 0 ? true : false;
        }

        public bool SolvedComment(int commentId)
        {
            var comment = _context.Set<Comment>().Where(x=> x.comment_id==commentId).SingleOrDefault();
            var ranking = _context.Set<Ranking>().Where(x => x.user_id == comment.user_id).SingleOrDefault();
            comment.status = CommentStatus.Correct;
            ranking.points += 5;
            return _context.SaveChanges() != 0 ? true : false;
        }
    }
}
