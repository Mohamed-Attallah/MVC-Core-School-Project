using System.ComponentModel.DataAnnotations.Schema;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Manager_Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public  virtual ICollection<Trainee> Trainees { get; set; }

    }
}
