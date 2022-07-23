using Microsoft.AspNetCore.Mvc;
using Iti_Core_Intake42_Q3_Project.Models;
using Microsoft.EntityFrameworkCore;
using Iti_Core_Intake42_Q3_Project.Repository;

namespace Iti_Core_Intake42_Q3_Project.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository Crs_Repo;
        IDepartmentRepository Dept_Repo;
        public CourseController(ICourseRepository C_Repo,IDepartmentRepository D_Repo)
        {
            Crs_Repo = C_Repo;
            Dept_Repo = D_Repo;
        }
        //ProjectContext DbContext = new ProjectContext();
        public IActionResult Index()
        {

            List<Course> Courses = Crs_Repo.GetAllWithDepts();//DbContext.Courses.Include(c=>c.Department).ToList();
            return View(Courses);
        }
        [HttpGet]
        public IActionResult AddNewCourse()
        {
            
            Course c = new Course();
            ViewBag.deptList = Dept_Repo.GetAll(); //DbContext.Departments.ToList();
            return View(c);
        }

       // [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SaveNewCourse(Course CRS)
        {
            if (ModelState.IsValid==true)
            {
                Crs_Repo.Insert(CRS);
                return RedirectToAction("Index");
            }

            ViewBag.deptList = Dept_Repo.GetAll(); ;//DbContext.Departments.ToList();
            return View("AddNewCourse", CRS);
            

        }
        public IActionResult CheckMinDegree(int MinDegree, int Degree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
            
        }
        public IActionResult EditCourse(int id)
        {
            ViewBag.deptList = Dept_Repo.GetAll(); ;//DbContext.Departments.ToList();
            Course crs = Crs_Repo.GetByID(id); //DbContext.Courses.Where(c => c.ID == id).FirstOrDefault();
            
            return View(crs);
        }
        public IActionResult SaveEditCourse(int id,Course crs)
        {
            if (ModelState.IsValid)
            {
                Course r = Crs_Repo.GetByID(id);//DbContext.Courses.FirstOrDefault(c => c.ID == ID);
                r.Name = crs.Name;
                r.DepartmentID = crs.DepartmentID;
                r.MinDegree = crs.MinDegree;
                r.Degree = crs.Degree;
                return RedirectToAction("Index");
            }
            ViewBag.deptList = Dept_Repo.GetAll(); //DbContext.Departments.ToList();
            return View("EditCourse", crs);

        }
    }
}
