using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Repositories;

namespace DotnetAPI.Services {

    public class UserService: IUserService {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public User GetUser(int UserId) {
            return _userRepository.GetUser(UserId);
        }

        public List<User> GetUsers() {
            return _userRepository.GetUsers();
        }

        public int CreateUser(CreateUserRequest Request)
        {
            return _userRepository.CreateUser(Request);
        }

        public User UpdateUser(UpdateUserRequest Request)
        {
            return _userRepository.UpdateUser(Request);
        }

        public void DeleteUser(int UserId)
        {
            _userRepository.DeleteUser(UserId);
        }

    }

}