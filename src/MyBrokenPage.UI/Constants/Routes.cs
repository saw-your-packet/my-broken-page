namespace MyBrokenPage.UI.Constants
{
    public static class Routes
    {
        public const string HomeController = "";
        public const string HomeControllerIndex = "";
        public const string HomeControllerCustomNotFound = "404";

        public const string SecurityController = "api/security";
        public const string SecurityControllerSqlInjection = "sqlinjection";

        public const string AccountsController = "";
        public const string AccountsControllerLogin = "login";
        public const string AccountsControllerLogout = "logout";
        public const string AccountsControllerRegister = "register";
        public const string AccountsControllerForgotPassword = "password-reset";
        public const string AccountsControllerVerifyUsername = "verify-username";

        public const string FeedController = "feed";
        public const string FeedControllerIndex = "";
        public const string FeedControllerDelete = "delete";
        public const string FeedControllerAddPost = "add-post";
        public const string FeedControllerPost = "posts";

        public const string UsersController = "users";
        public const string UsersControllerMyProfile = "my-profile";
        public const string UsersControllerUploadProfilePicture = "upload-profile-picture";

        public const string FilesController = "files";
        public const string FilesControllerIndex = "";
        public const string FilesControllerDownloadImage = "download";
        public const string FilesControllerUploadZip = "upload";
    }
}
