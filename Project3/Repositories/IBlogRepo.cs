using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PagedList;
using Project3.Entity.Dto;
using Project3.Entity.Request;
using Project3.Entity.Response;
using Project3.Migrations;
using Project3.Models;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Project3.Repositories
{
    public interface IBlogRepo
    {
        List<Blog> getBlogList();
        PageResponse<IPagedList<VBlogPagin>> paginations(BlogReq filter);
        void addOrUpdateBlogs(Blog blog);
        void deleteBlog(Blog blog);
        Blog getOne(float id);
    }

    public class BlogRepo : IBlogRepo
    {
        Project3Context _dbContext;
        public BlogRepo(Project3Context dbContext) 
        {
            _dbContext = dbContext;
        }

        public void addOrUpdateBlogs(Blog blog)
        {
            if(blog.Id == null)
            {
                _dbContext.Blogs.Add(blog);
            }
            else
            {
                _dbContext.Blogs.Update(blog);
            }
            _dbContext.SaveChanges();
        }

        public PageResponse<IPagedList<VBlogPagin>> paginations(BlogReq filter)
        {
            var param = new List<SqlParameter>();
            StringBuilder data = new StringBuilder("select b.Id,b.Title,b.CategoryId,b.CreatedAt from Blogs as b\r\nwhere b.IsDelete = 0 ");

            if(!string.IsNullOrEmpty(filter.title))
            {
                data.Append(" and LOWER(b.Title) LIKE '%' + @title + '%' ");
                param.Add(new SqlParameter("@title",SqlDbType.NVarChar ) { Value = filter.title.ToLower() });
            }
            if(filter.categoryId != null)
            {
                data.Append(" and b.CategoryId = @categoryId");
                param.Add(new SqlParameter("@categoryId", SqlDbType.VarChar) { Value = filter.categoryId });
            }
            var query = _dbContext.Set<Blog>().FromSqlRaw(data.ToString() , param.ToArray()).OrderBy(r => r.Title).ThenByDescending(r => r.CreatedAt).Select(
                r => new VBlogPagin
                {
                    Id = r.Id,
                    Title = r.Title,
                    CategoryId = r.CategoryId,
                    CreateAt = r.CreatedAt
                });

            var total = query.Count();

            var pageData = query.ToPagedList((int)filter.pageNumber, (int)filter.pageSize);

            var pageTotal = Math.Round((decimal)total / (int)filter.pageSize);

            return new PageResponse<IPagedList<VBlogPagin>>(pageData, (int)filter.pageNumber, (int)filter.pageSize, total,(int) pageTotal);
        }

        public Blog getOne(long id)
        {
            var data =  _dbContext.Blogs.Where(r => r.Id == id).First();

            return data;
        }
        
        public List<Blog> getBlogList()
        {
            return _dbContext.Blogs.Where(r => r.IsDelete == 0).ToList();       
        }

        public void deleteBlog(Blog blog)
        {
            _dbContext.Blogs.Update(blog);
            _dbContext.SaveChanges();
        }
    }
}
