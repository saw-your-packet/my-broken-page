using MyBrokenPage.UI.Controllers;

namespace MyBrokenPage.UI.Constants
{
    public static class Names
    {
        public const string Accounts = "Accounts";
        public const string AccountsControllerForgotPassword = nameof(AccountsController.ForgotPassword);
        public const string AccountsControllerLogout = nameof(AccountsController.Logout);
        public const string AccountsControllerLogin = nameof(AccountsController.Login);
        public const string AccountsControllerVerifyUsername = nameof(AccountsController.VerifyUsername);

        public const string Feed = "Feed";
        public const string FeedControllerIndex = nameof(FeedController.Index);
        public const string FeedControllerGetPost = nameof(FeedController.GetPost);

        public const string Home = "Home";
        public const string HomeControllerIndex = nameof(HomeController.Index);
        public const string HomeControllerCustomNotFound = nameof(HomeController.CustomNotFound);

        public const string Users = "Users";
        public const string UsersControllerMyProfile = nameof(UsersController.MyProfile);
        public const string UsersControllerUploadProfilePicture = nameof(UsersController.UploadProfilePicture);

        public const string Files = "Files";
        public const string FilesControllerDownload = nameof(FilesController.DownloadImage);
    }
}
