using Project3.Migrations;
using Project3.Models;
using System.Reflection.Metadata;

namespace Project3.Repositories
{
    public interface ICategoryBlogRepo
    {
        List<CategoryBlog> getCategoryList();
        void addOrUpdateCategoryBlog(CategoryBlog categoryblog);
        void deleteCategoryBlog(CategoryBlog categoryBlog);
        CategoryBlog getOne(float id);

    }
    public class CategoryBlogRepo : ICategoryBlogRepo
    {
        Project3Context _dbContext;
        public CategoryBlogRepo(Project3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void addOrUpdateCategoryBlog(CategoryBlog categoryblog)
        {
            if (categoryblog.Id == null)
            {
                _dbContext.CategoryBlogs.Add(categoryblog);
            }
            else
            {
                _dbContext.CategoryBlogs.Update(categoryblog);
            }
            _dbContext.SaveChanges();
        }

        public void deleteCategoryBlog(CategoryBlog categoryBlog)
        {
            _dbContext.CategoryBlogs.Update(categoryBlog);
            _dbContext.SaveChanges();
        }

        public List<CategoryBlog> getCategoryList()
        {
            return _dbContext.CategoryBlogs.Where(r => r.Id == 0).ToList();
        }

        public CategoryBlog getOne(float id)
        {
            var data = _dbContext.CategoryBlogs.Where(r => r.Id == id).First();

            return data;
        }

    }
}
