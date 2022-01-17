using System.Linq;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
#nullable disable
        private readonly DatabaseContext db;
        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<List<User>> GetAll() => await Task.Run(() => db.Users.ToList());

        public async Task<User> GetUser(int userId) => await Task.Run(() => db.Users.Find(userId));

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await Task.Run(() => db.Users.Add(user));
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
