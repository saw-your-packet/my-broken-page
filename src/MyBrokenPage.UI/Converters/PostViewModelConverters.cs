using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;

namespace MyBrokenPage.UI.Converters
{
    public static class PostViewModelConverters
    {
        public static PostModel ToModel(this PostViewModel postViewModel)
        {
            return new PostModel
            {
                Id = postViewModel.Id,
                Content = postViewModel.Content,
                User = new UserModel { Username = postViewModel.Username },
                Tooltip=postViewModel.Tooltip
            };
        }

        public static PostViewModel ToViewModel(this PostModel postModel)
        {
            return new PostViewModel
            {
                Id = postModel.Id,
                Content = postModel.Content,
                Username = postModel.User?.Username,
                Tooltip=postModel.Tooltip
            };
        }
    }
}
