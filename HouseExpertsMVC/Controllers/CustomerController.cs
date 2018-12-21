using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HouseExpertsMVC.Models;

namespace HouseExpertsMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context = ApplicationDbContext.Create();

        public ActionResult Index()
        {
            var customers = context.Customers.ToList();
           return View(customers);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                CustomerTypes = context.CustomerTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.ID == 0)
            {
                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Index", "Customer");
            }
            else
            {
                var customerInDB = context.Customers.Single(c => c.ID == customer.ID);
                customerInDB.FirstName = customer.FirstName;
                customerInDB.LastName = customer.LastName;
                customerInDB.CustomerTypeID = customer.CustomerTypeID;
                customerInDB.IsAcive = customer.IsAcive;
            }

            context.SaveChanges();
            return RedirectToAction("Details", "Customer", new {id =customer.ID});
        }

        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.CustomerType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }


        public ActionResult Update(int id)
        {
            var customer = context.Customers.Include(c => c.CustomerType).SingleOrDefault(C => C.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel() {Customer = customer
                , CustomerTypes = context.CustomerTypes.ToList()};
            return View("CustomerForm", viewModel);
        }
    }
}