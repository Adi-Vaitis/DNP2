using System;
using System.Collections.Generic;
using System.Linq;
using DNP2.Models;

namespace DNP2.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User()
                {
                    UserName = "admin",
                    Password = "123456",
                    Role = "Admin",
                    SecurityLevel = "3"
                }
            }.ToList();
        }

        public User ValidateUser(string UserName, string Password)
        {
            User first = users.FirstOrDefault(user => user.UserName.ToLower().Equals(UserName.ToLower()));

            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}