using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetCrud.Data;
using dotnetCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetCrud.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public async Task<IEnumerable<User>> SearchUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> SearchUser(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}