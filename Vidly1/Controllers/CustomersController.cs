using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.ViewModels;
using Vidly1.Models;
using System.Data.Entity;

namespace Vidly1.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //This is necessary due the fact some validation is hit when shouldn't
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {            
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer); //Save on memory
                }
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                    // TryUpdateModel(customerInDb); // This permit to update all fiields in the database for customer

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.MenbershipTypeId = customer.MenbershipTypeId;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                }

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            else
            {
                _context.SaveChanges(); // Save on database
            }                
                return RedirectToAction("Index", "Customers");                                   
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include( c =>  c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customersMember = _context.Customers.Include(c => c.MembershipType).ToList();
            if (customer == null)
                return HttpNotFound();
            if (customersMember == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null) 
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var deleteCustomer = _context.Customers.Find(customer.Id);
            try
            {
                if (customer.Id != 0)
                {
                    _context.Customers.Remove(deleteCustomer);
                    _context.SaveChanges();
                }
            }catch 
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Index", "Customers");
         }
    }
}