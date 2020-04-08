using Microsoft.AspNetCore.Mvc;
using sqlinj.Filters;
using sqlinj.Models;
using sqlinj.Repository;

namespace sqlinj.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index(string fullName = "")
        {
            var employees = employeeRepository.GetAllEmployees(fullName);

            return View(employees);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult New(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            employeeRepository.Create(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}