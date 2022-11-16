using AdvanceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvanceWeb.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasNoKey();
        }*/
    }
}
