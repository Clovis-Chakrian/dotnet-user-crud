using dotnetCrud.Models;

namespace dotnetCrud.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchUsers();
        Task<User> SearchUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangesAsync();

    }
}