using Microsoft.EntityFrameworkCore;
using StudyAPI.Model;

namespace StudyAPI.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
    }
}
