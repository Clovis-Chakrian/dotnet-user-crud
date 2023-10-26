using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCrud.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int Id);
        Task<Boolean> CreateUser(User user);
        Task<Boolean> UpdateUser(int Id, User user);
        Task<Boolean> DeleteUser(int Id);
    }
}