using Microsoft.AspNetCore.Mvc;
using  Iti_Core_Intake42_Q3_Project.Models;
using Iti_Core_Intake42_Q3_Project.Repository;

namespace Iti_Core_Intake42_Q3_Project.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepository InstructorRepository;
        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;
        public InstructorController(IInstructorRepository Ins_Repo, ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            InstructorRepository = Ins_Repo;
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            //var query= DbContext.Set<ResultViewModel>().Where(e => e.Pass == true); access the class without DbSet();

            List<Instructor> InstructorList = InstructorRepository.GetAll();//DbContext.Instructors.ToList();
            return View(InstructorList);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = InstructorRepository.GetByID(id);//DbContext.Instructors.Where(x => x.ID == id).FirstOrDefault();
            return View(instructor);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            ViewBag.CrsList = CourseRepository.GetAll();//DbContext.Courses;
            ViewBag.DeptList = DepartmentRepository.GetAll();//DbContext.Departments;
            Instructor ins= new Instructor();
            return View(ins);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Instructor instructor)
        {
            if (instructor.Name == null)
            {
                ViewBag.CrsList = CourseRepository.GetAll();//DbContext.Courses;
                ViewBag.DeptList = DepartmentRepository.GetAll();//DbContext.Departments;
                return View("AddNew",instructor);
            }
            //DbContext.Instructors.Add(instructor);
            //DbContext.SaveChanges();
            InstructorRepository.Insert(instructor);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Instructor instructor = InstructorRepository.GetByID(id);//DbContext.Instructors.Where(x => x.ID == id).FirstOrDefault();
            return View(instructor);
        }
        public IActionResult ConfirmDelete(int id)
        {
            //Instructor ins = InstructorRepository.GetByID(id);//DbContext.Instructors.Where(i => i.ID == id).FirstOrDefault();
            //DbContext.Instructors.Remove(ins);
            //DbContext.SaveChanges();
            InstructorRepository.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Instructor ins = InstructorRepository.GetByID(id);//DbContext.Instructors.FirstOrDefault(ins => ins.ID == id);
            ViewBag.CrsList = CourseRepository.GetAll();//DbContext.Courses;
            ViewBag.DeptList = DepartmentRepository.GetAll();//DbContext.Departments;
            return View("Edit",ins);
        }
        public IActionResult SaveEdit(int id, Instructor Old_Instructor)
        {
            //Instructor New_Instructor = InstructorRepository.GetByID(id); //DbContext.Instructors.FirstOrDefault(i => i.ID == id);
            //New_Instructor.Name = Old_Instructor.Name;
            //New_Instructor.Salary = Old_Instructor.Salary;
            //New_Instructor.Address = Old_Instructor.Address;
            //New_Instructor.DepartmentID = Old_Instructor.DepartmentID;
            //New_Instructor.CourseID = Old_Instructor.CourseID;
            //New_Instructor.Image = Old_Instructor.Image;
            //DbContext.SaveChanges();
            InstructorRepository.Update(id,Old_Instructor);
            return RedirectToAction("Index");

        }
        public IActionResult HandleAjax(int dept_id)
        {
           return Json(CourseRepository.GetAllByDepartmentID(dept_id));
        }

    }
}
