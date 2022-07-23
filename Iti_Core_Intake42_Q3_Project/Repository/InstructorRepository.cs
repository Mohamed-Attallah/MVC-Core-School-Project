using Iti_Core_Intake42_Q3_Project.Models;

namespace Iti_Core_Intake42_Q3_Project.Repository
{
    public class InstructorRepository: IInstructorRepository
    {
        ProjectContext Context;
        public InstructorRepository(ProjectContext _context)
        {
            Context = _context;
        }
        public List<Instructor> GetAll()
        {
            return Context.Instructors.ToList();
        }
        public Instructor GetByID(int id)
        {
            return Context.Instructors.FirstOrDefault(i => i.ID == id);
        }
        public void Insert(Instructor ins)
        {
            Context.Instructors.Add(ins);
            Context.SaveChanges();
        }
        public void Update(int id,Instructor Old_Instructor)
        {
            Instructor New_Instructor = Context.Instructors.FirstOrDefault(i => i.ID == id);
            New_Instructor.Name = Old_Instructor.Name;
            New_Instructor.Salary = Old_Instructor.Salary;
            New_Instructor.Address = Old_Instructor.Address;
            New_Instructor.DepartmentID = Old_Instructor.DepartmentID;
            New_Instructor.CourseID = Old_Instructor.CourseID;
            New_Instructor.Image = Old_Instructor.Image;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Instructor ins = Context.Instructors.Where(i => i.ID == id).FirstOrDefault();
            Context.Instructors.Remove(ins);
            Context.SaveChanges();
        }
    }

    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetByID(int id);
        void Insert(Instructor ins);
        void Update(int id, Instructor Old_Instructor);
        void Delete(int id);
    }
}
