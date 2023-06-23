using Microsoft.EntityFrameworkCore;


namespace ReactAspCrud.Models
{
    public class StudentDbContext : DbContext 
    {
       
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=theok\\SQLEXPRESS;Initial Catalog=StudentService2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }                              //Data Source=theok\\SQLEXPRESS;Initial Catalog=StudentService2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False











    }
}
