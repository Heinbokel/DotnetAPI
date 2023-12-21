
using System.Data;
using Dapper;
using DotnetAPI.Models;
using DotnetAPI.Repositories.Configuration;

namespace DotnetAPI.Repositories {

    public class UserRepository: IUserRepository {

        private static readonly string GET_USERS_SQL = @"
            SELECT * FROM TutorialAppSchema.Users
        ".Trim();

        private static readonly string WHERE_USER_ID_EQUALS = @"
            WHERE TutorialAppSchema.Users.UserId = @UserId
        ".Trim();

        private IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection) {
            this._dbConnection = dbConnection;
        }

        public User GetUser(int UserId) {
            var Params = new {
                UserId = UserId
            };
            return _dbConnection.QuerySingle<User>(GET_USERS_SQL + WHERE_USER_ID_EQUALS, Params);
        }

        public List<User> GetUsers() {
            return _dbConnection.Query<User>(GET_USERS_SQL).ToList();
        }

    }

}