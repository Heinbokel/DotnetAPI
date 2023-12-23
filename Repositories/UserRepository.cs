
using System.Data;
using Dapper;
using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Repositories.Configuration;

namespace DotnetAPI.Repositories {

    public class UserRepository: IUserRepository {

        private static readonly string GET_USERS_SQL = @"
            SELECT * FROM TutorialAppSchema.Users
        ".Trim();

        private static readonly string WHERE_USER_ID_EQUALS = @"
            WHERE TutorialAppSchema.Users.UserId = @UserId
        ".Trim();

        private static readonly string CREATE_USER_SQL = @"
            CREATE TABLE #InsertedUser (UserId INT);
            INSERT INTO
                TutorialAppSchema.Users(
                    FirstName,
                    LastName,
                    Email,
                    Gender,
                    Active
                )
                OUTPUT inserted.UserId INTO #InsertedUser
                VALUES (
                    @FirstName,
                    @LastName,
                    @Email,
                    @Gender,
                    @Active
                )
            SELECT UserId FROM #InsertedUser;

            DROP TABLE #InsertedUser;
        ".Trim();

        private static readonly string UPDATE_USER_SQL = @"";


        private static readonly string DELETE_USER_SQL = @"";


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

        public int CreateUser(CreateUserRequest Request)
        {
            var Params = new {
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                Email = Request.Email,
                Gender = Request.Gender,
                Active = Request.Active,
            };
            return _dbConnection.QuerySingle<int>(CREATE_USER_SQL, Params);
        }

        public User UpdateUser(UpdateUserRequest Request)
        {
            return _dbConnection.QuerySingle<User>(UPDATE_USER_SQL);
        }

        public void DeleteUser(int UserId)
        {
            _dbConnection.Query(DELETE_USER_SQL);
        }
    }

}