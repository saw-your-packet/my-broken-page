namespace MyBrokenPage.Common
{
    public static class DatabaseConfigurations
    {
        public const string DatabaseName = "MyBrokenPage";

        public const string SecureProcedureName = "GetByCredentials";

        public const string VulnerableProcedureName = "GetByCredentialsVuln";

        internal static SqlInjectionTestingEnum SelectedSqlInjectionMethod { get; set; } = SqlInjectionTestingEnum.QueryStringConcatenation;
    }
}
