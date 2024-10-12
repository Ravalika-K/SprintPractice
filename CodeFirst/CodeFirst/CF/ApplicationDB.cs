using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.CF
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options):base(options)
        {
            
        }
        //create table in a database
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
