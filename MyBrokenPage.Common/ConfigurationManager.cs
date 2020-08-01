namespace MyBrokenPage.Common
{
    public class ConfigurationManager
    {
        public static bool IsSecurityEnabled { get; set; }

        public static void SwitchSecurityFlag()
        {
            IsSecurityEnabled = !IsSecurityEnabled;
        }

        public static void ResetSecurityFlag()
        {
            IsSecurityEnabled = false;
        }
    }
}
