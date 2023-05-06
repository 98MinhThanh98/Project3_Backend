using Microsoft.EntityFrameworkCore;
using PagedList;
using Project3.Entity.Response;
using Project3.Migrations;
using Project3.Models;

namespace Project3.Repositories
{
    public interface IUserRepo
    {
        User getUserByEmail(string email);
        PageResponse<IPagedList<User>> search();
        User findById(string? id);
        string createOrUpdate(User user);
        User getById(string id);

    }

    public class UserRepo : IUserRepo
    {
        Project3Context _context;
        public UserRepo(Project3Context context) 
        {
            _context = context;
        }

        public string createOrUpdate(User user)
        {
            throw new NotImplementedException();
        }

        public User findById(string? id)
        {
            throw new NotImplementedException();
        }

        public User getById(string id)
        {
            throw new NotImplementedException();
        }

        public User getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public PageResponse<IPagedList<User>> search()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.First(u => u.UserName == username);
        }

        public void AddUserAsync(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChangesAsync();
        }
    }
}
