
using System.Data;
using Dapper;
using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Repositories.Configuration;

namespace DotnetAPI.Repositories {

    public class UserRepository: IUserRepository {

        private static readonly string GET_USERS_SQL = @"
            SELECT * FROM TutorialAppSchema.Users
        ";

        private static readonly string WHERE_USER_ID_EQUALS = @"
            WHERE TutorialAppSchema.Users.UserId = @UserId
        ";

        private static readonly string CREATE_USER_SQL = @"
            DECLARE @InsertedUserId INT;            
            INSERT INTO
                    TutorialAppSchema.Users(
                    FirstName,
                    LastName,
                    Email,
                    Gender,
                    Active
                )
                OUTPUT inserted.UserId INTO @InsertedUserId;
                VALUES (
                    @FirstName,
                    @LastName,
                    @Email,
                    @Gender,
                    @Active
                )
            SELECT @InsertedUserId AS InsertedUserId;
        ";

        private static readonly string UPDATE_USER_SQL = @"
            UPDATE 
                TutorialAppSchema.Users
            SET 
                FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                Gender = @Gender,
                Active = @Active
        ";


        private static readonly string DELETE_USER_SQL = @"
            DELETE FROM
                TutorialAppSchema.Users
        ";


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

        public User UpdateUser(UpdateUserRequest Request, int UserId)
        {
            var Params = new {
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                Email = Request.Email,
                Gender = Request.Gender,
                Active = Request.Active,
                UserId = UserId
            };
            _dbConnection.Execute(UPDATE_USER_SQL + WHERE_USER_ID_EQUALS, Params);
            return new User(){
                UserId = UserId,
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                Email = Request.Email,
                Gender = Request.Gender,
                Active = Request.Active,
            };
        }

        public void DeleteUser(int UserId)
        {
            var Params = new{
                UserId = UserId
            };
            int deletedRows = _dbConnection.Execute(DELETE_USER_SQL +  WHERE_USER_ID_EQUALS, Params);
            if (deletedRows < 1) {
                throw new Exception($"User {UserId} not found for deletion");
            }
        }
    }

}