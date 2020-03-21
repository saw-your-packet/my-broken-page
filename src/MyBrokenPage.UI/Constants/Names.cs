using MyBrokenPage.UI.Controllers;

namespace MyBrokenPage.UI.Constants
{
    public static class Names
    {
        public const string Accounts = nameof(Accounts);
        public const string AccountsControllerForgotPassword = nameof(AccountsController.ForgotPassword);
        public const string AccountsControllerLogout = nameof(AccountsController.Logout);
        public const string AccountsControllerLogin = nameof(AccountsController.Login);
        public const string AccountsControllerVerifyUsername = nameof(AccountsController.VerifyUsername);

        public const string Feed = nameof(Feed);
        public const string FeedControllerIndex = nameof(FeedController.Index);

        public const string Home = nameof(Home);
        public const string HomeControllerIndex = nameof(HomeController.Index);
    }
}
