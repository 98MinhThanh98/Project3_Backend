using Project3.Migrations;
using Project3.Models;
using System.Data;

namespace Project3.Repositories
{
    public interface IUserRepo
    {
        bool UserExistsByUsername(string username);
        User getById(long id);
        void AddUser(User user);
    }

    public class UserRepo : IUserRepo
    {
        Project3Context _context;
        public UserRepo(Project3Context context)
        {
            _context = context;
        }

        public bool UserExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }

        public void AddUser(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChangesAsync();
        }

        public User getById(long id)
        {
            return _context.Users.Where(i => i.Id == id).First();
        }
    }
}
