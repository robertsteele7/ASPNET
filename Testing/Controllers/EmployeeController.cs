using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var employees = repo.GetAllEmployees();

            return View(employees);
        }
        public IActionResult ViewEmployee(int id)
        {
            var employee = repo.GetEmployee(id);

            return View(employee);
        }
        public IActionResult UpdateEmployee(int id)
        {
            Employee emp = repo.GetEmployee(id);

            if (emp == null)
            {
                return View("EmployeeNotFound");
            }

            return View(emp);
        }
        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            repo.UpdateEmployee(employee);

            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID });
        }
        public IActionResult InsertEmployee()
        {
            var emp = repo.CreateEmptyEmployeeObject();

            return View(emp);
        }
        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            repo.InsertEmployee(employeeToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee);

            return RedirectToAction("Index");
        }
    }
}
