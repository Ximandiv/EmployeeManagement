using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var viewModel = getEmployeeList(page, pageSize);

            return View(viewModel);
        }

        public PartialViewResult GetEmployees(int page = 1, int pageSize = 10)
        {
            var viewModel = getEmployeeList(page, pageSize);

            return PartialView("_EmployeeTableView", viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeContext())
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

                return Json(new { success = true, message = "Employee created successfully!" });
            }
            catch
            {
                return Json(new { success = false, message = "There was an error creating an employee" });
            }
        }

        public ActionResult Edit(int id)
        {
            using(var context = new EmployeeContext())
            {
                var employeeModel = context.Employees.FirstOrDefault(em => em.Id == id);

                if (employeeModel != null)
                    return View(employeeModel);
                else
                    return View("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(Employee employee)
        {
            using(var context = new EmployeeContext())
            {
                var existingEmployee = context.Employees.Find(employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Position = employee.Position;
                    existingEmployee.Office = employee.Office;
                    existingEmployee.Salary = employee.Salary;

                    context.SaveChanges();

                    return Json(new { success = true, message = "Employee was updated" });
                }

                return Json(new { success = false, message = "Employee was not found" });
            }
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            using (var context = new EmployeeContext())
            {
                var employeeModel = context.Employees
                                            .FirstOrDefault(em => em.Id == id);

                if (employeeModel != null)
                    context.Employees.Remove(employeeModel);
                else
                    return Json(new { success = false, message = "Employee was not found"});

                context.SaveChanges();

                return Json(new { success = true, message = "Employee was deleted" });
            }
        }

        private EmployeeListVM getEmployeeList(int page, int pageSize)
        {
            using (var context = new EmployeeContext())
            {
                /* 
                 * Skips the current page - 1 * page size to understand
                 * location so it can then take the amount of page size
                 */
                var employees = context.Employees.OrderBy(e => e.Id)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize).ToList();

                var totalEmployees = context.Employees.Count();

                return new EmployeeListVM
                {
                    Employees = employees,
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalCount = totalEmployees
                };
            }
        }
    }
}
