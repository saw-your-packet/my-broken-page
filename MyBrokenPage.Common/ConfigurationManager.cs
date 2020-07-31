using Microsoft.Extensions.Configuration;
using MyBrokenPage.Common.SQLi;

namespace MyBrokenPage.Common
{
    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public static bool IsSecurityEnabled { get; set; }
        public DatabaseConfigurations DatabaseConfigs { get; set; }

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
            DatabaseConfigs = configuration.GetSection(nameof(DatabaseConfigurations)).Get<DatabaseConfigurations>();
        }

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
