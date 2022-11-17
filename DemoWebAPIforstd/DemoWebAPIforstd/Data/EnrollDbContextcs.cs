
using DemoWebAPIforstd.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIforstd.Data
{
    public class EnrollDbContextcs: DbContext
    {
        public EnrollDbContextcs(DbContextOptions<EnrollDbContextcs> options) : base(options)
        {

        }
        public DbSet<Enrolls> Enroll { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<Subjectss> Subject { get; set; }
       
    }
}
