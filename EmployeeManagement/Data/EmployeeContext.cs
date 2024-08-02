using EmployeeManagement.Models;
using System.Data.Entity;

namespace EmployeeManagement.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext() : base("name=EmployeeContext")
        {
            
        }
    }
}