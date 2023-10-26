using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetCrud.Models;
using dotnetCrud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCrud.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _repository.SearchUsers();
            return users;
        }

        public async Task<User> GetUserById(int Id)
        {
            var user = await _repository.SearchUser(Id);
            return user;
        }

        public async Task<bool> CreateUser(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(int Id, User user)
        {
             var bdUser = await _repository.SearchUser(Id);
            if (bdUser == null) return false;

            bdUser.Name = user.Name ?? bdUser.Name;
            bdUser.BirthDate = user.BirthDate != new DateTime() ? user.BirthDate : bdUser.BirthDate;

            _repository.UpdateUser(bdUser);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(int Id)
        {
            var bdUser = await _repository.SearchUser(Id);
            if (bdUser == null) return false;

            _repository.DeleteUser(bdUser);
            return await _repository.SaveChangesAsync();
        }
    }
}