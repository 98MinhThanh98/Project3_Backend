using PagedList;
using Project3.Entity.Response;
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
}
