using System.ComponentModel.DataAnnotations.Schema;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class Trainee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Grade { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual List<Crs_Result> Crs_Results { get; set; }
        public virtual Department Department { get; set; }
    }
}
