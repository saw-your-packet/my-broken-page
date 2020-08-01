namespace MyBrokenPage.Common.SQLi
{
    public enum SqlInjectionTestingEnum
    {
        QueryStringConcatenation,
        Linq,
        QueryInterpolated,
        QueryParameterizedFromSqlRaw,
        StoredProcedureSecureParameterized,
        StoredProcedureSecureInterpolated,
        StoredProcedureSecureFromSqlRaw,
        StoredProcedureInsecureParameterized
    }
}
