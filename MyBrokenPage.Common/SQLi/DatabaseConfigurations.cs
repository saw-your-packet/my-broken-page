namespace MyBrokenPage.Common.SQLi
{
    public class DatabaseConfigurations
    {
        public string DataSource { get; set; }

        public string DatabaseName { get; set; }

        public bool IntegratedSecurity { get; set; }

        public int ConnectTimeout { get; set; }

        public bool Encrypt { get; set; }

        public bool TrustServerCertificate { get; set; }

        public string ApplicationIntent { get; set; }

        public bool MultiSubnetFailover { get; set; }

        public string SecureProcedureName { get; set; }

        public string VulnerableProcedureName { get; set; }

        public SqlInjectionTestingEnum SelectedSqlInjectionMethod { get; set; } = SqlInjectionTestingEnum.QueryStringConcatenation;

        public string GetConnectionString()
        {
            var connectionString = $"Data Source={DataSource};Initial Catalog={DatabaseName};Integrated Security={IntegratedSecurity};Connect Timeout={ConnectTimeout};Encrypt={Encrypt};TrustServerCertificate={TrustServerCertificate};ApplicationIntent={ApplicationIntent};MultiSubnetFailover={MultiSubnetFailover}";

            return connectionString;
        }
    }
}
