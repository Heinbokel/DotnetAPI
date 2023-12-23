
using System.Data;
using Dapper;
using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Repositories.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetAPI.Repositories {

    public class UserRepositoryEF: IUserRepository {

        private DataContextEF _entityFramework;
        public UserRepositoryEF(DataContextEF EntityFramework) {
            _entityFramework = EntityFramework;
        }

        public User GetUser(int UserId) {
            User? User = _entityFramework.Users
            .Where(u => u.UserId == UserId)
            .FirstOrDefault();

            if (User != null) {
                return User;
            }

            throw new Exception($"User {UserId} not found");
        }

        public List<User> GetUsers() {
            return _entityFramework.Users.ToList<User>();
        }

        public int CreateUser(CreateUserRequest Request)
        {
            User User = new User(){
                    FirstName = Request.FirstName,
                    LastName = Request.LastName,
                    Email = Request.Email,
                    Gender = Request.Gender,
                    Active = Request.Active,
                };
            _entityFramework.Add(User);
            _entityFramework.SaveChanges();

            //UserId is generated and added onto the object automatically.
            return User.UserId;
        }

        public User UpdateUser(UpdateUserRequest Request, int UserId)
        {
            User User = GetUser(UserId);

            User.FirstName = Request.FirstName;
            User.LastName = Request.LastName;
            User.Email = Request.Email;
            User.Gender = Request.Gender;
            User.Active = Request.Active;

            int UpdatedRows = _entityFramework.SaveChanges();

            if (UpdatedRows > 0) {
                return new User(){
                    UserId = UserId,
                    FirstName = Request.FirstName,
                    LastName = Request.LastName,
                    Email = Request.Email,
                    Gender = Request.Gender,
                    Active = Request.Active,
                };
            }

            throw new Exception($"User {UserId} could not be updated");
        }

        public void DeleteUser(int UserId)
        {
            User User = GetUser(UserId);

            _entityFramework.Users.Remove(User);
            int UpdatedRows = _entityFramework.SaveChanges();

            if (UpdatedRows > 0) {
                return;
            }

            throw new Exception($"User {UserId} was not found for deletion.");
        }
    }

}