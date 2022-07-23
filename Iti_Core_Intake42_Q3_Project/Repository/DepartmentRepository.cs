using Iti_Core_Intake42_Q3_Project.Models;

namespace Iti_Core_Intake42_Q3_Project.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
    }
    public class DepartmentRepository: IDepartmentRepository
    {
        ProjectContext _Context;
        public DepartmentRepository(ProjectContext _context)
        {
            _Context= _context;
        }
        public List<Department> GetAll()
        {
            return _Context.Departments.ToList();
        }
    }

    
}
