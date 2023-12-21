
using System.Data;
using Dapper;
using DotnetAPI.Models;
using DotnetAPI.Repositories.Configuration;

namespace DotnetAPI.Repositories {

    public class UserRepository: IUserRepository {

        private static readonly string GET_USERS_SQL = "";

        private IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection) {
            this._dbConnection = dbConnection;
        }

        public List<User> GetUsers() {
            return new List<User>() {
                new User(){UserId = 1, Active = true, Email = "email@gmail.com", FirstName = "first", LastName = "lasdfast", Gender = "male"},
                new User(){UserId = 2, Active = true, Email = "312@gmail.com", FirstName = "firstt", LastName = "lasdfast", Gender = "female"},
                new User(){UserId = 3, Active = true, Email = "4234@gmail.com", FirstName = "fitttrst", LastName = "laasdst", Gender = "female"},
                new User(){UserId = 4, Active = false, Email = "5253@gmail.com", FirstName = "firttst", LastName = "lasdfast", Gender = "male"},
                new User(){UserId = 5, Active = true, Email = "523532@yahoo.com", FirstName = "ftttirst", LastName = "last", Gender = "female"}
            };
        }

    }

}