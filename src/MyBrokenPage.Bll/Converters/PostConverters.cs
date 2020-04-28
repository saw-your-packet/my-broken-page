using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Converters
{
    public static class PostConverters
    {
        public static PostModel ToPostModel(this Post post)
        {
            return new PostModel
            {
                Id = post.Id,
                Content = post.Content,
                User = post.User.ToUserModel()
            };
        }

        public static Post ToPost(this PostModel postModel, int userId)
        {
            return new Post
            {
                Content = postModel.Content,
                UserId = userId
            };
        }
    }
}
