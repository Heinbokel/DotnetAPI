using DotnetAPI.Models;
using DotnetAPI.Repositories;

namespace DotnetAPI.Services {

    public class UserService: IUserService {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public List<User> GetUsers() {
            return _userRepository.GetUsers();
        }

    }

}