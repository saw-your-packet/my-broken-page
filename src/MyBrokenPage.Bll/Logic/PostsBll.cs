using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Converters;
using MyBrokenPage.Bll.Exceptions;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBrokenPage.Bll.Logic
{
    public class PostsBll : IPostsBll
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserBll _userBll;

        public PostsBll(IPostRepository postRepository, IUserBll userBll)
        {
            _postRepository = postRepository;
            _userBll = userBll;
        }

        public IEnumerable<PostModel> GetAll(string search)
        {
            return _postRepository.GetAll(search)
                                  .Select(p => p.ToPostModel())
                                  .ToList();
        }

        public void Delete(int id, string username)
        {
            var post = _postRepository.GetById(id);

            if (post.User.Username == username)
            {
                _postRepository.Delete(post);
            }
            else
            {
                throw new ExceptionNotAuthorized($"User {username} tried to delete post with id {id}");
            }
        }

        public void Add(PostModel post)
        {
            var user = _userBll.GetByUsername(post.User.Username);

            if (user == null)
            {
                throw new ExceptionResourceNotFound($"User {post.User.Username} not found.");
            }

            _postRepository.Add(post.ToPost(user.Id));
        }
    }
}
