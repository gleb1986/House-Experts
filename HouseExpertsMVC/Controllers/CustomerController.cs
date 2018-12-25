using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HouseExpertsMVC.Models;

namespace HouseExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();

        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
           return View(customers);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                CustomerTypes = _context.CustomerTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }

            var customerInDB = _context.Customers.Single(c => c.ID == customer.ID);
            customerInDB.FirstName = customer.FirstName;
            customerInDB.LastName = customer.LastName;
            customerInDB.CustomerTypeID = customer.CustomerTypeID;
            customerInDB.IsAcive = customer.IsAcive;
            customerInDB.DateModified = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Details", "Customer", new {id =customer.ID});
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.CustomerType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }


        public ActionResult Update(int id)
        {
            var customer = _context.Customers.Include(c => c.CustomerType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                CustomerTypes = _context.CustomerTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}