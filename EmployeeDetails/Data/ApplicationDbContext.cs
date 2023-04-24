using EmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<EmpDetails> Details { get; set; }  
        
    }
}
