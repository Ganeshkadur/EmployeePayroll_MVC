using Employee_Buseness.Interfaces;
using Employee_Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EmployeePayroll_MVC.Controllers
{

    public class EmployeeControllercs : Controller
    {
        private readonly IEmployee_Buseness _business;
        
       public EmployeeControllercs(IEmployee_Buseness business)
        {
            _business = business;
        }

        [HttpGet("getall")]
        public IActionResult GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = _business.GetAllEmployees().ToList();

            return View(lstEmployee);
        }


        [HttpGet("getallbyname")]
        public IActionResult GetAllEmployeeByName(string name)
        {
            List<Employee> lst=new List<Employee>();
            lst = _business.GetEmployeesByName(name).ToList();
            return View(lst);
        }




        [HttpGet]
        [Route("Create")]
        public IActionResult CreateEmployee()
        {

            return View();
        }

        [HttpPost]
        [Route("Create")]

        public IActionResult CreateEmployee([Bind]EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _business.CreateEmployee(model);
                    return View(model);

                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                return View(model);
            }
            

        }


        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            try
            {
                var result = _business.GetElementById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return View(result);

            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult DeleteConfermation(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _business.DeleteEmployeeById(id);
                    return RedirectToAction("GetAllEmployee");

                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return RedirectToAction("GetAllEmployee");
            }

        }



        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = _business.GetElementById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost("Edit/{id}"), ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Employee employee)
        {
            try
            {
                
                if (ModelState.IsValid)
                {

                    _business.UpdateEmployeeById(employee);
                    return RedirectToAction("GetAllEmployee");
                }
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(employee);
            }
        }



        [HttpGet]
       /* [Route("GetEmployeeById/{id}")]*/
        public IActionResult GetEmployeeById(int id)
        {
             id = (int)HttpContext.Session.GetInt32("EmployeeId");

            if (id == null)
            {
                return NotFound();
            }
            Employee employee = _business.GetElementById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);


          
           
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login([Bind] Employee model)
        {
            try
            {

                if (model.EmployeeId <1 || string.IsNullOrEmpty(model.FullName))
                { 
                    return BadRequest($"Invalid input parameters {model.EmployeeId} or {model.FullName}");
                }


                Employee employee = _business.Login(model.EmployeeId, model.FullName);

                if (employee == null)
                {
                    return BadRequest($"Invalid input {model.EmployeeId} or {model.FullName} Please enter valid Input");
                }


                HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                HttpContext.Session.SetString("FullName", employee.FullName);


                return RedirectToAction("GetEmployeeById", new { id = employee.EmployeeId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
