using Employee_Buseness.Interfaces;
using Employee_Repository.Entities;
using Employee_Repository.Interfaces;
using ModelLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_BusenessLayer.Services
{
    public class EmployeeBuseness:IEmployee_Buseness
    {
        private readonly IEmployee_Repository _repo;
        public EmployeeBuseness(IEmployee_Repository repo)
        {
            _repo = repo;
        }

       public Employee UpdateEmployeeById(Employee employee)
        {
            return _repo.UpdateEmployeeById(employee);
        }

        public void DeleteEmployeeById(int id)
        {
            _repo.DeleteEmployeeById(id);
        }


        public Employee GetElementById(int id)
        {
            return _repo.GetElementById(id);
        }
        public void CreateEmployee(EmployeeModel employee)
        {
            _repo.CreateEmployee(employee);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repo.GetAllEmployees();
        }

        public Employee Login(int EmployeeId, string FullName)
        {
            return _repo.Login(EmployeeId, FullName);
        }

        public IEnumerable<Employee> GetEmployeesByName(string name)
        {
            return _repo.GetEmployeesByName(name);
        }

    }
}
