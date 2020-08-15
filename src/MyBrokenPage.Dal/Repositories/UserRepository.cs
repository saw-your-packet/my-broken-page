using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Models;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Common.SQLi;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public User GetUserByCredentials(string username, string password)
        {
            string query;
            User result;

            var parameters = new[]
            {
                new SqlParameter("@username", SqlDbType.NVarChar){Direction = ParameterDirection.Input, Value = username},
                new SqlParameter("@password", SqlDbType.NVarChar){Direction = ParameterDirection.Input, Value = password}
            };

            switch (DatabaseConfigurations.SelectedSqlInjectionMethod)
            {
                case SqlInjectionTestingEnum.QueryStringConcatenation:
                    query = $"SELECT * FROM dbo.Users WHERE Username = '{username}' and Password = '{password}'";
                    result = _entities.FromSqlRaw(query)
                                      .Include(x => x.Role)
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.Linq:
                    result = _entities.Where(x => x.Username == username && x.Password == password)
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.QueryInterpolated:
                    FormattableString formattableQuery = $"SELECT * FROM dbo.Users WHERE Username = {username} and Password = {password}";
                    result = _entities.FromSqlInterpolated(formattableQuery)
                                      .Include(x => x.Role)
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.QueryParameterizedFromSqlRaw:
                    query = "SELECT * FROM dbo.Users WHERE Username = @username and Password = @password";
                    result = _entities.FromSqlRaw(query, parameters)
                                      .Include(x => x.Role)
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.StoredProcedureSecureParameterized:
                    result = _entities.FromSqlRaw("GetByCredentials @username, @password", parameters)
                                      .ToList()
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.StoredProcedureSecureInterpolated:
                    result = _entities.FromSqlInterpolated($"GetByCredentials {username}, {password}")
                                      .ToList()
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.StoredProcedureSecureFromSqlRaw:
                    query = $"GetByCredentials {username}, {password}";
                    result = _entities.FromSqlRaw(query)
                                      .ToList()
                                      .FirstOrDefault();
                    break;
                case SqlInjectionTestingEnum.StoredProcedureInsecureParameterized:
                    result = _entities.FromSqlRaw("GetByCredentialsVuln @username, @password", parameters)
                                      .ToList()
                                      .FirstOrDefault();
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }


        public bool IsUsernameUsed(string username)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}'";

            return _entities.FromSqlRaw(query).FirstOrDefault() != null;
        }

        public User GetUserByUsername(string username)
        {
            return _entities.Include(u => u.Role)
                            .Where(user => user.Username == username)
                            .FirstOrDefault();
        }
    }
}
