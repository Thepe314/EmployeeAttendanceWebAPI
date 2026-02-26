
using HRMANAGEMENTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMANAGEMENTAPI.Data
{
   public class ApplicationDbContext : DbContext 
{
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees {get;set;}

    public DbSet<Attendance> Attendances {get;set;}
}

}