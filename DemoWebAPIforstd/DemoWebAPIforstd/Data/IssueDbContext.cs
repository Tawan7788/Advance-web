using DemoWebAPIforstd.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIforstd.Data
{
    public class IssueDbContext: DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext>options): base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; }

    }
}
