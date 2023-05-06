<<<<<<< HEAD
﻿using Project3.Migrations;
using Project3.Models;
using System.Reflection.Metadata;

namespace Project3.Repositories
{
    public interface ICourseRepo
    {
        List<Course> GetCourseList();
        void addOrUpdateCourseRepo(Course course);
        void deleteCourseRepo(Course course);
        Course getOne(long id);
    }
    public class CourseRepo : ICourseRepo
    {
        Project3Context _dbContext;
        public CourseRepo(Project3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void addOrUpdateCourseRepo(Course course)
        {
            if(course.Id == null)
            {
                _dbContext.Courses.Add(course);
            }
            else{
                _dbContext.Courses.Update(course);
            }
            _dbContext.SaveChanges();
        }

        public void deleteCourseRepo(Course course)
        {
            _dbContext.Courses.Update(course);
            _dbContext.SaveChanges();
        }

        public List<Course> GetCourseList()
        {
            return _dbContext.Courses.Where(r => r.Id == 0).ToList();
        }

        public Course getOne(long id)
        {
            var data = _dbContext.Courses.Where(r => r.Id == id).First();

            return data;
        }
=======
﻿namespace Project3.Repositories
{
    public interface ICourseRepo
    {
>>>>>>> cff46de88ecb6444047ba605511d28812d678132
    }
}
