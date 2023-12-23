using System.Data;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.Repositories.Configuration {
    
public class DataContextDapper {

    private readonly string _connectionString;

    public DataContextDapper(string connectionString) {
        this._connectionString = connectionString;
    }

    public IDbConnection GetConnection() {
        return new SqlConnection(this._connectionString);
    }
}

}