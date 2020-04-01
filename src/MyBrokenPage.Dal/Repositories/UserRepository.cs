using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System;
using System.Data;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }


        public User GetUserByCredentials(string username, string password)
        {
            var parameters = new[]
                {
                new SqlParameter("@username", SqlDbType.NVarChar){Direction = ParameterDirection.Input, Value = username},
                new SqlParameter("@password", SqlDbType.NVarChar){Direction = ParameterDirection.Input, Value = password}
            };

            bool isStoredprocedure = true;
            if (isStoredprocedure)
            {
                var storedProcedureResult = _entities.FromSqlRaw("GetByCredentials @username, @password", parameters)
                                                     .ToList()
                                                     .FirstOrDefault();

                var storedProcedureQuery = $"GetByCredentials {username}, {password}";
                var storedProcedureResult2 = _entities.FromSqlRaw(storedProcedureQuery)
                                                      .ToList()
                                                      .FirstOrDefault();

                var storedProcedureResult3 = _entities.FromSqlInterpolated($"GetByCredentials {username}, {password}")
                                                      .ToList()
                                                      .FirstOrDefault();

                return storedProcedureResult;
            }
            else
            {
                FormattableString query = $"SELECT * FROM dbo.Users WHERE Username = {username} and Password = {password}";
                var queryFromResult = _entities.FromSqlInterpolated(query)
                                               .Include(x => x.Role)
                                               .FirstOrDefault();

                var query1 = $"SELECT * FROM dbo.Users WHERE Username = '{username}' and Password = '{password}'";
                var queryResultResult1 = _entities.FromSqlRaw(query1)
                                                  .Include(x => x.Role)
                                                  .FirstOrDefault();
               
                var query2 = "SELECT * FROM dbo.Users WHERE Username = @username and Password = @password";
                var queryResultResult2 = _entities.FromSqlRaw(query2, parameters)
                                                  .Include(x => x.Role)
                                                  .FirstOrDefault();
               
                return queryResultResult1;
            }
        }


        public bool IsUsernameUsed(string username)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}'";

            return _entities.FromSqlRaw(query).FirstOrDefault() != null;
        }

        public User GetUserByUsername(string username)
        {
            return _entities.Where(user => user.Username == username)
                            .FirstOrDefault();
        }
    }
}
