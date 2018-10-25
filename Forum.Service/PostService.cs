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
    public class PostService : Service<Post>, IPostService
    {
        private PostRepository _repo;
        private UserService _user;
        public PostService(PostRepository repo, UserService user) : base(repo)
        {
            _repo = repo;
            _user = user;

        }

        public bool AddPost(Post post,int id)
        {
            post.date = DateTime.Now;
            post.user_id = id;
            post.status = PostStatus.Unsolved;
            post.activity = PostActivity.Active;
            _user.EditLastPost(id);
            return _repo.Add(post);
        }

        public bool DeletePost(int id)
        {
            return _repo.DeletePost(id);
        }

        public bool EditPost(Post post)
        {
            return _repo.EditPost(post);
        }

        public bool HidePost(Post post)
        {
            return _repo.HidePost(post);
        }

        public bool SolvedPost(int postId)
        {
            return _repo.SolvedPost(postId);
        }

        public bool SolvedComment(int commentId)
        {
            return _repo.SolvedComment(commentId);
        }

        public IEnumerable<Post> GetAllByPostsId(int id)
        {
            return _repo.GetAllByPostsId(id);
        }
    }
}
