using UserService.Database.Entities;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<List<User>> GetAll();
        Task<User> GetUser(int userId);
    }
}