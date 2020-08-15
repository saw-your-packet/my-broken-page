namespace MyBrokenPage.Common
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
