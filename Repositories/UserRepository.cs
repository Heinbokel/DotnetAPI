
using System.Data;
using Dapper;
using DotnetAPI.Repositories.Configuration;

namespace DotnetAPI.Repositories {

    public class UserRepository: IUserRepository {

        private static readonly string GET_USERS_SQL = "";

        private IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection) {
            this._dbConnection = dbConnection;
        }

        public string[] GetAllUsers() {
            return new string[] {
                "SUCCESSFUL RETRIEVAL", this._dbConnection.ConnectionString, "ANOTHER STRING"
            };
        }

    }

}