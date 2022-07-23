using System.ComponentModel.DataAnnotations.Schema;
namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class Crs_Result
    {
        public int ID { get; set; }
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("Trainee")]

        public int TraineeID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
