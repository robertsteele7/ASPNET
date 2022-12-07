using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void UpdateEmployee(Employee employee);
        public void InsertEmployee(Employee employeeToInsert);
        public IEnumerable<Employee> GetEmployeeID();
        public Employee CreateEmptyEmployeeObject();
        public void DeleteEmployee(Employee employee);
    }
}
