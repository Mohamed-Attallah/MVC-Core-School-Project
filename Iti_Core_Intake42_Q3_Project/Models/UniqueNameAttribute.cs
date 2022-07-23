using System.ComponentModel.DataAnnotations;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    internal class UniqueNameAttribute : ValidationAttribute
    {
        ProjectContext context; //new ProjectContext();
            public UniqueNameAttribute(ProjectContext _c)
        {
            context = _c;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
                return null;
            string n = value.ToString();
            var crs = context.Courses.Where(c => c.Name == n).FirstOrDefault();
            if (crs != null)
            {
                Course CRS = (Course)validationContext.ObjectInstance;
              
                
                var course = context.Courses.Where(c => c.ID == CRS.ID).FirstOrDefault();
                if(course==null)
                   return new ValidationResult("Name must be Unique");
                else
                {
                    int c = context.Courses.Where(x => x.ID != CRS.ID && x.Name==n).Count();
                    if(c==0)
                       return ValidationResult.Success;
                    else
                        return new ValidationResult("you try to mdify Another Course with this name Exists");
                }

            } 
            
            else
            return ValidationResult.Success; 
        }
    }
}