using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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
            base.Dispose(disposing);
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);

        }
        
        public ActionResult New()
        { 
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = _context.Customers.Add(new Customer()),
                MembershipTypes = membershipTypes
            };
            //return View(viewModel);
            //without this, it will look for a form matching the method name.
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == id);
            if (customer == null)
                return RedirectToAction("Index");

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);  // officialy recommended; could have security holes
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" }); //officialy recommended whitelisting - depends on "magic string" and could break if the model changes.
                //This method allows the same granular control as whitelisting, but will be properly refactored if proprties are renamed.
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                //Tools such as Auto-Mapper can simplify the code for updating all properties.
                //dto - data transfer objects - can also be used with Auto-Mapper to limit fields to those which can be updated.

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


    }
}