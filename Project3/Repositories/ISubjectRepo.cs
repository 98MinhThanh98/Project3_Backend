
﻿using Project3.Migrations;
using Project3.Models;

namespace Project3.Repositories
{
    public interface ISubjectRepo
    {
        List<Subject> getSubjectList();
        void CreateOrUpdateSubjectRepo(Subject subject);
        void DeleteSubject(Subject subject);
        Subject getOne(long id);
    }
    public class SubjectRepo : ISubjectRepo
    {
        Project3Context _dbContext;
        public SubjectRepo(Project3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateOrUpdateSubjectRepo(Subject subject)
        {
            if (subject.Id == null)
            {
                _dbContext.Subjects.Add(subject);
            }
            else
            {
                _dbContext.Subjects.Update(subject);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteSubject(Subject subject)
        {
            _dbContext.Subjects.Update(subject);
            _dbContext.SaveChanges();
        }

        public Subject getOne(long id)
        {
            var data = _dbContext.Subjects.Where(r => r.Id == id).First();

            return data;
        }

        public List<Subject> getSubjectList()
        {
            return _dbContext.Subjects.Where(r => r.Id == 0).ToList();
        }
    }
}
