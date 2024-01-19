using Employee_Repository.Entities;
using ModelLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Employee_Buseness.Interfaces
{
    public interface IEmployee_Buseness
    {
        public Employee UpdateEmployeeById(Employee employee);
        public void DeleteEmployeeById(int id);
        public Employee GetElementById(int id);
        public void CreateEmployee(EmployeeModel employee);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee Login(int EmployeeId, string FullName);
        public IEnumerable<Employee> GetEmployeesByName(string name);

    }
}
