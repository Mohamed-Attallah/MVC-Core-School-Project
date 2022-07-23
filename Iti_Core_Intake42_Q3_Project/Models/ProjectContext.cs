using Microsoft.EntityFrameworkCore;

namespace Iti_Core_Intake42_Q3_Project.Models
{
    public class ProjectContext:DbContext
    {
        public  DbSet<Department> Departments { get; set; }
        public  DbSet<Trainee> Trainees { get; set; }
        public  DbSet<Instructor> Instructors { get; set; }
        public  DbSet<Course> Courses { get; set; }
        public  DbSet<Crs_Result> Crs_Results { get; set; }
        public ProjectContext()
        {
           
        }
        public ProjectContext(DbContextOptions options):base(options)
        {

        }


        // public DbSet<Class_Name> Class_Names { get;set }//create Dbset for the mapping class
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //   // base.OnConfiguring(new );
        //    optionsBuilder.UseSqlServer(@"Data Source=MOHAMMED\MYSQLSERVER;Initial Catalog=Intake42_Q3;Integrated Security=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Class_Name>.hasNoKey().ToView(); //map class to view
        }
    }
}
