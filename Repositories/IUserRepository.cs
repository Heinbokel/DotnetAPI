using DotnetAPI.Models;

namespace DotnetAPI.Repositories {

public interface IUserRepository {

    public List<User> GetUsers();

}

}