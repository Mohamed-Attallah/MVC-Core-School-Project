using System.ComponentModel.DataAnnotations.Schema;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Department Department { get; set; }
        public virtual Course Course { get; set; }
    }
}
