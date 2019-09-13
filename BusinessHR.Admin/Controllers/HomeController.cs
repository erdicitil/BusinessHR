using AutoMapper;
using BusinessHR.Admin.Models;
using BusinessHR.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IPermissionService permissionService;
        public HomeController(IEmployeeService employeeService,IPermissionService permissionService)
        {
            this.employeeService = employeeService;
            this.permissionService = permissionService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var employee = Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeService.GetAll());
            return View(employee);
        }

       
    }
}
