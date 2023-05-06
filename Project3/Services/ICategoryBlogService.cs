using Project3.Entity.Request;
using Project3.Entity.Response;
using Project3.Models;
using Project3.Repositories;
using Project3.Utils;

namespace Project3.Services
{
    public interface ICategoryBlogService
    {
        BaseResponse getOne(long id);
        BaseResponse deleteCategoy(long id);
        BaseResponse createOrUpdate(AddBlogReq blogReq);
        BaseResponse getPagin(BlogReq filter);
    }
    public class CategoryBlogService : ICategoryBlogService
    {
        ICategoryBlogRepo _categoryBlogRepo;
        CategoryBlog categoryBlog;
        public CategoryBlogService(ICategoryBlogRepo categoryBlogRepo)
        {
            _categoryBlogRepo = categoryBlogRepo;
        }

        public BaseResponse createOrUpdate(AddBlogReq blogReq)
        {
            throw new NotImplementedException();
        }

        public BaseResponse deleteCategoy(long id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse getOne(long id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse getPagin(BlogReq filter)
        {
            throw new NotImplementedException();
        }
    }
}
