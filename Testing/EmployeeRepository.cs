using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _conn;
        public EmployeeRepository(IDbConnection conn) 
        {
            _conn = conn;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("Select * FROM EMPLOYEES e ORDER BY e.EmployeeID DESC");
        }
        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM EMPLOYEES WHERE EMPLOYEEID = @id",
                new { id = id });
        }
        public void UpdateEmployee(Employee employee)
        {   _conn.Execute("UPDATE employees SET firstName = @firstname, MiddleInitial = @middleInitial, LastName = @lastName,  EmailAddress = @emailAddress, PhoneNumber = @phoneNumber, Title = @title, DateOfBirth = @dateofbirth WHERE EmployeeID = @id",
                new { firstname = employee.FirstName, middleinitial = employee.MiddleInitial, lastname = employee.LastName, phoneNumber = employee.PhoneNumber, emailAddress = employee.EmailAddress, title = employee.Title, dateofbirth = employee.DateOfBirth, id = employee.EmployeeID });
        }
        public void InsertEmployee(Employee employeeToInsert)
        {  _conn.Execute("INSERT INTO employees (FIRSTNAME, MIDDLEINITIAL, LASTNAME, EMAILADDRESS, PHONENUMBER, TITLE, DATEOFBIRTH) VALUES (@firstname, @middleinitial, @lastname, @emailaddress, @phonenumber, @title, @dateofbirth);",
                new { firstname = employeeToInsert.FirstName, middleinitial = employeeToInsert.MiddleInitial, lastname = employeeToInsert.LastName, emailaddress = employeeToInsert.EmailAddress, phonenumber = employeeToInsert.PhoneNumber, title = employeeToInsert.Title, dateofbirth = employeeToInsert.DateOfBirth});
        }
   
        public Employee CreateEmptyEmployeeObject()
        {
          
            var employee = new Employee();
     
            return employee;
        }
        public void DeleteEmployee(Employee employee)
        {
            
            _conn.Execute("DELETE FROM Sales WHERE EmployeeID = @id;",
                                       new { id = employee.EmployeeID });
            _conn.Execute("DELETE FROM Employees WHERE EmployeeID = @id;",
                                       new { id = employee.EmployeeID });
        }

        public IEnumerable<Employee> GetEmployeeID()
        {
            throw new NotImplementedException();
        }
    }
}
