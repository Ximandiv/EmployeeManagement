using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class EmployeeListVM
    {
        public List<Employee> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)System.Math.Ceiling((double)TotalCount / PageSize);
    }
}