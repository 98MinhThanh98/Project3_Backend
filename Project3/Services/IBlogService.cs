using Project3.Entity.Dto;
using Project3.Entity.Request;
using Project3.Entity.Response;
using Project3.Models;
using Project3.Repositories;
using Project3.Utils;

namespace Project3.Services
{
    public interface IBlogService
    {
        BaseResponse getOne(long id);
        BaseResponse getPagin(BlogReq filter);
        BaseResponse deleteBlog(long id);
        BaseResponse createOrUpdate(AddBlogReq blogReq);
    }

    public class BlogService : IBlogService
    {
        IBlogRepo _blogRepo;
        Blog blog;

        public BlogService(IBlogRepo blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public BaseResponse createOrUpdate(AddBlogReq blogReq)
        {
            if(blogReq.Id  == null)
            {
                this.blog = new Blog();
                this.blog.IsDelete = Constants.IsDelete.False;
                this.blog.CreatedAt = DateTime.Now;
            }
            else
            {
                this.blog = _blogRepo.getOne((long)blogReq.Id);
                if(this.blog == null)
                {
                    throw new DataNotFoundException(MESSAGE.VALIDATE.OBJECT_NOT_FOUND);
                }
                this.blog.UpdateAt = DateTime.Now;
            }

            convertFromDtoToModel(blogReq);
            _blogRepo.addOrUpdateBlogs(this.blog);
            return new BaseResponse();
        }

        private void convertFromDtoToModel(AddBlogReq blogs) 
        {
            blog.Id = (long)blogs.Id;
            blog.Title = blogs.Title;
            blog.Summay = blogs.Summay;
            blog.UsersId = blogs.UsersId;
            blog.CategoryId = blogs.CategoryId;
        }

        public BaseResponse deleteBlog(long id)
        {
            var data = _blogRepo.getOne(id);
            if(data == null)
            {
                throw new DataNotFoundException(MESSAGE.VALIDATE.OBJECT_NOT_FOUND);
            }
            data.IsDelete = 1;
            data.UpdateAt = DateTime.Now;
            _blogRepo.deleteBlog(data);

            return new BaseResponse();
        }

        public BaseResponse getOne(long id)
        {
            var data = _blogRepo.getOne(id);
            if(data == null)
            {
                return new BaseResponse();
            }
            var format = new VBlogOne
            {
                Id = data.Id,
                Title = data.Title,
                Summary = data.Summay,
                UserId = data.UsersId,
                CategoryId = data.CategoryId,
                CreateAt = data.CreatedAt
            };
            return new BaseResponse(format);
        }

        public BaseResponse getPagin(BlogReq filter)
        {
            var data = _blogRepo.paginations(filter);
            return new BaseResponse(data);
        }
    }
}
