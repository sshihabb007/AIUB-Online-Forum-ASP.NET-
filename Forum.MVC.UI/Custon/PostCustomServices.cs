using Forum.Entity;
using Forum.Service;
using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Web.Mvc.Models;

namespace Forum.MVC.UI.Custon
{
    public class PostCustomServices
    {
        PostService _postService;
        UserService _userService;
        PostVoteService _voteService;
        CommentService _commentService;
        CommentVoteService _commentVoteService;
        ReplyService _replyService;
        ReplyVoteService _replyVoteService;
        RankingService _rankingService;
        ComplainService _complainService;

        public PostCustomServices(PostService postService, PostVoteService voteService, CommentService commentService, UserService userService, CommentVoteService commentVoteService, ReplyService replyService, ReplyVoteService replyVoteService, RankingService rankingService, ComplainService complainService)
        {
            _postService = postService;
            _voteService = voteService;
            _commentService = commentService;
            _userService = userService;
            _commentVoteService = commentVoteService;
            _replyService = replyService;
            _replyVoteService = replyVoteService;
            _rankingService = rankingService;
            _complainService = complainService;
        }

        public IEnumerable<AllPost> GetAllPost(int userId)
        {
            var posts = _postService.GetAll().OrderByDescending(x=> x.date);
            List<AllPost> list = new List<AllPost>();
            foreach (var item in posts)
            {
                if(item.activity!=PostActivity.Inactive)
                {
                    int val = _rankingService.GetRankById(item.user_id);
                    int likes = _voteService.LikeCount(item.post_id);
                    int dislikes = _voteService.DislikeCount(item.post_id);
                    int nones = _voteService.NoneCount(item.post_id);
                    int responses = _commentService.CommentCount(item.post_id);
                    string name = _userService.GetById(item.user_id).full_name;
                    AllPost post = new AllPost();
                    post.Id = item.post_id;
                    post.Title = item.title;
                    post.Body = item.body;
                    post.Tag = item.tags;
                    post.userID = item.user_id;
                    post.userPoint = val;
                    post.Name = name;
                    post.Status = item.status;
                    post.MyVote = _voteService.MyVoteStatus(item.post_id, userId);
                    post.Score = likes - dislikes;
                    post.Vote = likes + dislikes + nones;
                    post.Response = responses;
                    list.Add(post);
                }
                
            }
            return list;
        }

        public IEnumerable<AllPost> ManagePosts(int userId)
        {
            var posts = _postService.GetAllByPostsId(userId).OrderByDescending(x => x.date);
            List<AllPost> list = new List<AllPost>();
            foreach (var item in posts)
            {
                string name = _userService.GetById(item.user_id).full_name;
                AllPost post = new AllPost();
                post.Id = item.post_id;
                post.Title = item.title;
                post.Body = item.body;
                post.Tag = item.tags;
                post.Name = name;
                post.userPoint = _rankingService.GetRankById(item.user_id);
                post.Status = item.status;
                list.Add(post);
            }
            return list;
        }

        public PostDetails GetById(int id, int userId)
        {
            var data = _postService.GetById(id);

            int likes = _voteService.LikeCount(data.post_id);
            int dislikes = _voteService.DislikeCount(data.post_id);
            List<Models.Comment> comments = new List<Forum.MVC.UI.Models.Comment>();

            var commentsList = _commentService.GetAllByPostId(data.post_id);
            foreach (var item in commentsList)
            {

                List<Models.Reply> replies = new List<Models.Reply>();
                var repliesList = _replyService.GetAllByCommentId(item.comment_id);
                foreach (var items in repliesList)
                {
                    int _like = _replyVoteService.Likes(items.reply_id);
                    int _dislike = _replyVoteService.Dislikes(items.reply_id);
                    Models.Reply reply = new Models.Reply();
                    reply.Id = items.reply_id;
                    reply.userID = items.user_id;
                    reply.Name = _userService.GetById(items.user_id).full_name;
                    reply.reply = items.reply;
                    reply.Score = _like - _dislike;
                    reply.voteStatus = _replyVoteService.MyVoteStatus(items.reply_id,userId);
                    replies.Add(reply);
                }

                int likeCount = _commentVoteService.LikeCount(item.comment_id);
                int dislikeCount = _commentVoteService.DislikeCount(item.comment_id);
                Models.Comment comment = new Models.Comment();
                comment.Id = item.comment_id;
                comment.userID = item.user_id;
                comment.Name = _userService.GetById(item.user_id).full_name;
                comment.comment = item.comment;
                comment.Status = item.status;
                comment.voteStatus = _commentVoteService.MyVoteStatus(item.comment_id,userId);
                comment.Score = likeCount - dislikeCount;
                comment.Replies = replies;
                comments.Add(comment);
            }


            PostDetails post = new PostDetails();
            post.Id = data.post_id;
            post.userID = data.user_id;
            post.userPoint = _rankingService.GetRankById(data.user_id);
            post.Name = _userService.GetById(data.user_id).full_name;
            post.Title = data.title;
            post.Body = data.body;
            post.Tag = data.tags;
            post.Status = data.status;
            post.Score = likes - dislikes;
            post.MyVote = _voteService.MyVoteStatus(data.post_id, userId);
            post.comments = comments;
            post.myPost = data.user_id==userId ? true : false;
            return post;
        }        

        public SinglePost GetPostById(int id, int userId)
        {
            var data = _postService.GetById(id);
            SinglePost post = new SinglePost();
            post.Id = data.post_id;
            post.Name = _userService.GetById(data.user_id).full_name;
            post.userPoint = _rankingService.GetRankById(data.user_id);
            post.Title = data.title;
            post.Body = data.body;
            post.Tags = data.tags;
            post.Status = data.activity;
            return post;
        }

        public int LikeAPost(int postId, int userId, VoteStatus status, int userID)
        {
            Post_Vote vote = new Post_Vote
            {
                post_id = postId,
                user_id = userId,
                vote_status = status
            };
            return _voteService.AddVote(vote, userID);
        }

        public int LikeComment(int commentId, int userId, VoteStatus status, int userID)
        {
            Comment_Vote vote = new Comment_Vote
            {
                comment_id = commentId,
                user_id = userId,
                vote_status = status
            };
            return _commentVoteService.AddVote(vote, userID);
        }

        public int LikeReply(int replyId, int userId, VoteStatus status, int userID)
        {
            Reply_Vote vote = new Reply_Vote
            {
                reply_id = replyId,
                user_id = userId,
                vote_status = status
            };
            return _replyVoteService.AddVote(vote, userID);
        }

        public int DislikeAPost(int postId, int userId, VoteStatus status, int userID)
        {
            Post_Vote vote = new Post_Vote
            {
                post_id = postId,
                user_id = userId,
                vote_status = status
            };
            return _voteService.DeleteVote(vote, userID);
        }

        public int DislikeComment(int commentId, int userId, VoteStatus status, int userID)
        {
            Comment_Vote vote = new Comment_Vote
            {
                comment_id = commentId,
                user_id = userId,
                vote_status = status
            };
            return _commentVoteService.DeleteVote(vote, userID);
        }

        public int DislikeReply(int replyId, int userId, VoteStatus status, int userID)
        {
            Reply_Vote vote = new Reply_Vote
            {
                reply_id = replyId,
                user_id = userId,
                vote_status = status
            };
            return _replyVoteService.DeleteVote(vote, userID);
        }

        public int PostAComment(int postId, int userId, string comment)
        {
            Entity.Comment data = new Entity.Comment
            {
                post_id = postId,
                user_id = userId,
                comment = comment,
                status  = CommentStatus.None

            };
            return _commentService.Add(data)==true ? 1 : 2;
        }

        public int PostAReply(int commentId, int userId, string reply)
        {
            Entity.Reply data = new Entity.Reply
            {
                comment_id = commentId,
                user_id = userId,
                reply = reply
            };
            return _replyService.Add(data)==true ? 1 : 2;
        }

        public bool AddPost(SinglePost post,int id)
        {
            Entity.Post _post = new Entity.Post
            {
                title = post.Title,
                body = post.Body,
                tags = post.Tags
            };
            return _postService.AddPost(_post,id);
        }

        public bool EditPost(SinglePost post)
        {
            Entity.Post _post = new Entity.Post
            {
                post_id = post.Id,
                title = post.Title,
                body = post.Body,
                tags = post.Tags
            };
            return _postService.EditPost(_post);
        }

        public bool Privacy(SinglePost post)
        {
            Entity.Post _post = new Entity.Post
            {
                post_id = post.Id,
                title = post.Title,
                body = post.Body,
                tags = post.Tags,
            };
            return _postService.HidePost(_post);
        }

        public bool DeletePost(SinglePost post)
        {
            return _postService.DeletePost(post.Id);
        }

        public bool SolvedPost(int postId)
        {
            return _postService.SolvedPost(postId);
        }

        public bool SolvedComment(int commentId)
        {
            return _postService.SolvedComment(commentId);
        }

        public IEnumerable<Rank> Ranking()
        {
            List<Rank> list = new List<Rank>();
            int pos = 1;
            foreach (var item in _rankingService.GetAllRanks())
            {
                Rank rank = new Rank
                {
                    position = pos++,
                    name = _userService.GetById(item.user_id).full_name,
                    department = _userService.GetById(item.user_id).department,
                    points = item.points
                };
                list.Add(rank);
            }
            return list;
        }

        public IEnumerable<ComplainSearchUser> GetUser()
        {
            var users = _userService.GetAll();
            List<ComplainSearchUser> list = new List<ComplainSearchUser>();
            foreach (var item in users)
            {
                ComplainSearchUser data = new ComplainSearchUser
                {
                    Id = item.user_id,
                    Name = item.full_name,
                    Photo = item.photo
                };
                list.Add(data);
            }
            
            return list;
        }

        public bool AddComplain(int from, CustomComplain _complain)
        {
            Complain complain = new Complain
            {
                from_user = from,
                to_user = _complain.Id,
                complain = _complain.Subject,
                description = _complain.Description,
                status = ComplainStatus.Pending,
                date = DateTime.Now,
                notification = NotificationStatus.Unseen
            };
            return _complainService.Add(complain);
        }

        public ComplainArchive GetAllComplain(int id)
        {
            ComplainArchive archive = new ComplainArchive();
            var from_me = _complainService.GetAllFromMe(id);
            var about_Me = _complainService.GetAllAboutMe(id);
            List<CustomComplain> fromList = new List<CustomComplain>();
            List<CustomComplain> toList = new List<CustomComplain>();
            foreach (var item in from_me)
            {
                CustomComplain complain = new CustomComplain
                {
                    Id = item.complain_id,
                    Name = _userService.GetById(item.to_user).full_name,
                    Subject = item.complain,
                    Description = item.description,
                    Status = item.status
                };
                fromList.Add(complain);
            }
            foreach (var item in about_Me)
            {
                CustomComplain complain = new CustomComplain
                {
                    Id = item.complain_id,
                    Name = _userService.GetById(item.from_user).full_name,
                    Subject = item.complain,
                    Description = item.description,
                    Status = item.status
                };
                toList.Add(complain);
            }
            archive.fromMe = fromList;
            archive.AboutMe = toList;
            return archive;
        }

        public CustomComplain GetComplainDetailsAboutMe(int id)
        {
            var data = _complainService.GetById(id);
            CustomComplain complain = new CustomComplain
            {
                Id = data.complain_id,
                Name = _userService.GetById(data.from_user).full_name,
                Subject = data.complain,
                Description = data.description,
                Status = data.status
            };
            return complain;
        }

        public CustomComplain GetComplainDetailsFromMe(int id)
        {
            var data = _complainService.GetById(id);
            CustomComplain complain = new CustomComplain
            {
                Id = data.complain_id,
                Name = _userService.GetById(data.from_user).full_name,
                Subject = data.complain,
                Description = data.description,
                Status = data.status,
                date = data.date
            };
            return complain;
        }
    }
}