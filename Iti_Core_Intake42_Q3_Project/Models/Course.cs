using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Display(Name="Course Name")]
        [Required]
        [MaxLength(20,ErrorMessage ="must be less than 20 letters")]
        [MinLength(2,ErrorMessage ="must be greater than 2 letters")]
        public string Name { get; set; }
        [Required]
        [Range(50,100,ErrorMessage ="out of range")]
        public int Degree { get; set; }
        [Required]
        [Remote("CheckMinDegree", "Course",AdditionalFields ="Degree",ErrorMessage ="must be less than Degree")]
        public int MinDegree { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
       // public List<Instructor> Instructors { get; set; }
        public virtual Department? Department { get; set; }
       // public virtual List<Crs_Result> Crs_Results { get; set; }

    }
}
