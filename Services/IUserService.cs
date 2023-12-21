using DotnetAPI.Models;

namespace DotnetAPI.Services {

public interface IUserService {
        public User GetUser(int userId);
        public List<User> GetUsers();

}

}