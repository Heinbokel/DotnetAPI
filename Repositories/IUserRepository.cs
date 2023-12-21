using DotnetAPI.Models;

namespace DotnetAPI.Repositories {

public interface IUserRepository {
    public User GetUser(int UserId);

    public List<User> GetUsers();

}

}