namespace MyBrokenPage.Common.SQLi
{
    public class DatabaseConfigurations
    {
        public const string DatabaseName = "MyBrokenPage";

        public const string SecureProcedureName = "GetByCredentials";

        public const string VulnerableProcedureName = "GetByCredentialsVuln";

        public static SqlInjectionTestingEnum SelectedSqlInjectionMethod { get; set; } = SqlInjectionTestingEnum.QueryStringConcatenation;
    }
}
