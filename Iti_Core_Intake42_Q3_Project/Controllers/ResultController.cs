using Iti_Core_Intake42_Q3_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Iti_Core_Intake42_Q3_Project.Controllers
{
    public class ResultController : Controller
    {
        ProjectContext DbContext = new ProjectContext();
        public IActionResult Show(int id)
        {
            ResultViewModel res_mod = new ResultViewModel();
            List<Course>Courses=new List<Course>(); 
            Trainee t = DbContext.Trainees.FirstOrDefault(e => e.ID == id);
            List<Crs_Result> results = DbContext.Crs_Results.Where(e => e.TraineeID == id).ToList();
            foreach(var Result in results)
            {
                 
                var temp = DbContext.Courses.FirstOrDefault(e => e.ID == Result.CourseID);
                Courses.Add(temp);
            }
            res_mod.TraineeID = t.ID;
            res_mod.Trainee_Name = t.Name;
            res_mod.Course_Name = Courses[0].Name;
            res_mod.Degree = results[0].Degree;
            if (results[0].Degree < Courses[0].MinDegree)
                res_mod.Pass = false;
            else
                res_mod.Pass = true;
            return View(res_mod);
        }
        public IActionResult ShowAll(int id)
        {
            List<Course> Courses = new List<Course>();

            Trainee t = DbContext.Trainees.FirstOrDefault(e => e.ID == id);
            List<Crs_Result> results = DbContext.Crs_Results.Where(e => e.TraineeID== id).ToList();
            foreach (var Result in results)
            {
                var temp = DbContext.Courses.FirstOrDefault(e => e.ID == Result.CourseID);
                Courses.Add(temp);
            }
            List<ResultViewModel> Models = new List<ResultViewModel>();
            for(int i = 0; i < Courses.Count; i++)
            {
                ResultViewModel res_mod = new ResultViewModel();
                res_mod.TraineeID = t.ID;
                res_mod.Trainee_Name = t.Name;
                res_mod.Course_Name = Courses[i].Name;
                res_mod.Degree = results[i].Degree;
                if (results[i].Degree < Courses[i].MinDegree)
                    res_mod.Pass = false;
                else
                    res_mod.Pass = true;
                Models.Add(res_mod);
            }
            return View(Models);



        }
    }
}
