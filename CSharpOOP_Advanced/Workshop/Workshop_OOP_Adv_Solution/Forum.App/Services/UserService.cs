using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Forum.DataModels;
using Forum.Data;
using System.Linq;

namespace Forum.App.Services
{
    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users.First(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found!");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            User user = this.GetUserById(userId);

            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false; 
            }

            var users = forumData.Users;

            User user = forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return false;
            }

            this.session.Reset();

            this.session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsename = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsename || !validPassword)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

            User user = new User(userId, username, password);

            forumData.Users.Add(user);

            forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
