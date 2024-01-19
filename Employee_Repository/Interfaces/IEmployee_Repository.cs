using Employee_Repository.Entities;
using ModelLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Repository.Interfaces
{
    public interface IEmployee_Repository
    {
        public IEnumerable<Employee> GetAllEmployees();
        public void CreateEmployee(EmployeeModel employee);

        public Employee GetElementById(int id);
        public void DeleteEmployeeById(int id);

        public Employee UpdateEmployeeById(Employee employee);

        public Employee Login(int EmployeeId, string FullName);

        public IEnumerable<Employee> GetEmployeesByName(string name);
    }
}
