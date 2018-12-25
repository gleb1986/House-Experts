using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HouseExpertsMVC.Models;

namespace HouseExpertsMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();

        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel
            {
                EmployeeTypes = _context.EmployeeTypes.ToList()
            };
            return View("EmployeeForm", viewModel);
        }

        public ActionResult Save(Employee employee)
        {
            if (employee.ID == 0)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            var employeeInDB = _context.Employees.Single(c => c.ID == employee.ID);
            employeeInDB.FirstName = employee.FirstName;
            employeeInDB.LastName = employee.LastName;
            employeeInDB.EmployeeTypeID = employee.EmployeeTypeID;
            employeeInDB.IsAcive = employee.IsAcive;
            employeeInDB.DateModified = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Details", "Employee", new { id = employee.ID });
        
    }

        public ActionResult Details(int id)
        {
            var employee = _context.Employees.Include(e => e.EmployeeType).SingleOrDefault(e => e.ID == id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        public ActionResult Update(int id)
        {
            var employee = _context.Employees.Include(c => c.EmployeeType).SingleOrDefault(C => C.ID == id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeeFormViewModel()
            {
                Employee = employee,
                EmployeeTypes = _context.EmployeeTypes.ToList()
            };
            return View("EmployeeForm", viewModel);
        }
    }
}