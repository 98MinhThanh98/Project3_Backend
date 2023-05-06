<<<<<<< HEAD
﻿using Project3.Migrations;
using Project3.Models;

namespace Project3.Repositories
{
    public interface ITestFirstRepo
    {
        List<TestFirst> getListTestFirst();
        void addOrUpdateTestFirst(TestFirst testFirst);
        void deleteTestFirst(TestFirst testFirst);
        TestFirst getOne(long id);
    }
    public class TestFirstRepo : ITestFirstRepo 
    {
        Project3Context _dbContext;
        public TestFirstRepo(Project3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void addOrUpdateTestFirst(TestFirst testFirst)
        {
            if(testFirst.Id == null)
            {
                _dbContext.TestFirsts.Add(testFirst);
            }
            else
            {
                _dbContext.TestFirsts.Update(testFirst);
            }
            _dbContext.SaveChanges();
        }


        public void deleteTestFirst(TestFirst testFirst)
        {
            _dbContext.TestFirsts.Update(testFirst);
            _dbContext.SaveChanges();
        }

        public List<TestFirst> getListTestFirst()
        {
            return _dbContext.TestFirsts.Where(r => r.Id == 0).ToList();
        }

        public TestFirst getOne(long id)
        {
            var data = _dbContext.TestFirsts.Where(r => r.Id == id).First();

            return data;
        }
=======
﻿namespace Project3.Repositories
{
    public interface ITestFirstRepo
    {
>>>>>>> cff46de88ecb6444047ba605511d28812d678132
    }
}
