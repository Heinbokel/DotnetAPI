using DotnetAPI.Models;
using DotnetAPI.Models.Requests;

namespace DotnetAPI.Repositories {

public interface IUserRepository {
    public User GetUser(int UserId);

    public List<User> GetUsers();

    public int CreateUser(CreateUserRequest Request);

    public User UpdateUser(UpdateUserRequest Request, int UserId);

    public void DeleteUser(int UserId);

}

}