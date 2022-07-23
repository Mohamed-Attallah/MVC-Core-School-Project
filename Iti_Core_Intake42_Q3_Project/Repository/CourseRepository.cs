using Iti_Core_Intake42_Q3_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Iti_Core_Intake42_Q3_Project.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        List<Course> GetAllWithDepts();
        List<Course> GetAllByDepartmentID(int dept_id);
        Course GetByID(int id);
        void Insert(Course crs);
        void Update(int id, Course crs);
        void Delete(int id);
    }
    public class CourseRepository : ICourseRepository
    {
        ProjectContext Context;
        public CourseRepository(ProjectContext _context)
        {
            Context = _context;
        }
        public List<Course> GetAllWithDepts()
        {
            return Context.Courses.Include(c => c.Department).ToList();
        }
        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }
        public Course GetByID(int id)
        {
            Course crs = Context.Courses.FirstOrDefault(c => c.ID == id);
            return crs;
        }
        public List<Course> GetAllByDepartmentID(int dept_id)
        {
            return Context.Courses.Where(c => c.DepartmentID == dept_id).ToList();
        }
        

        public void Insert(Course crs)
        {
            Context.Courses.Add(crs);
            Context.SaveChanges();
        }
        public void Update(int id,Course crs)
        {
            Course old = Context.Courses.FirstOrDefault(c=>c.ID==id);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Course crs = GetByID(id);
            Context.Courses.Remove(crs);
            Context.SaveChanges();
        }
    }


}
