using DotnetAPI.Models;
using DotnetAPI.Models.Requests;

namespace DotnetAPI.Services {

public interface IUserService {
        public User GetUser(int UserId);
        public List<User> GetUsers();

        public int CreateUser(CreateUserRequest Request);

        public User UpdateUser(UpdateUserRequest Request, int UserId);

        public void DeleteUser(int UserId);

}

}