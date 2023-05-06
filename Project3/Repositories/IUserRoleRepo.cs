using Microsoft.EntityFrameworkCore;
using Project3.Migrations;
using Project3.Models;

namespace Project3.Repositories
{
    public interface IUserRoleRepo
    {
        IEnumerable<UserRole> getAllUserRole();
        void SaveUserRole(UserRole user);
        UserRole GetUserRoleById(long id);
        void UpdateUserRole(UserRole user);
    }

    public class UserRoleRepo : IUserRoleRepo
    {
        Project3Context _context;
        public UserRoleRepo(Project3Context context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> getAllUserRole()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(long id)
        {
            return _context.UserRoles.Where(r => r.Id == id).First();
        }

        public void SaveUserRole(UserRole user)
        {
            _context.UserRoles.Add(user);
            _context.SaveChangesAsync();
        }

        public void UpdateUserRole(UserRole user)
        {
            _context.UserRoles.Update(user);
            _context.SaveChangesAsync();
        }
    }
}
