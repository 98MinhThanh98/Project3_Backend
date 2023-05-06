using Project3.Migrations;
using Project3.Models;

namespace Project3.Repositories
{
    public interface IInformationStudentRepo
    {
        List<InformationStudent> getInformationList();
        void addOrUpdateInformationStudent(InformationStudent informationStudent);
        void deleteInformationStudent(InformationStudent informationStudent);
        InformationStudent getOne(long id);
    }
    public class InformationStudentRepo : IInformationStudentRepo
    {
        Project3Context _dbContext;
        public InformationStudentRepo(Project3Context dbContext)
        {
            _dbContext = dbContext;
        }
        public List<InformationStudent> getInformationList()
        {
            return _dbContext.InformationStudents.Where(r => r.Id == 0).ToList();
        }

        public void addOrUpdateInformationStudent(InformationStudent informationStudent)
        {
            if (informationStudent.Id == null)
            {
                _dbContext.InformationStudents.Add(informationStudent);
            }
            else
            {
                _dbContext.InformationStudents.Update(informationStudent);
            }
            _dbContext.SaveChanges();
        }

        public void deleteInformationStudent(InformationStudent informationStudent)
        {
            _dbContext.InformationStudents.Update(informationStudent);
            _dbContext.SaveChanges();
        }

        public InformationStudent getOne(long id)
        {
            var data = _dbContext.InformationStudents.Where(r => r.Id == id).First();

            return data;
        }
    }
}
