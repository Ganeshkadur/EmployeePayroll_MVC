using Employee_Buseness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayroll_MVC.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private readonly IEmployee_Buseness _buseness;
       public AjaxController(IEmployee_Buseness buseness)
        {
               _buseness = buseness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployeeByAjax()
        {
            var data=_buseness.GetAllEmployees();
            return new JsonResult(data);
        }
    }
}
