using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerWithAuthMVC_app.Models.ViewModel;
using System.Data.Entity;
using System.Net;
using System.IO;
using System.Net.Http;

namespace MovieCustomerWithAuthMVC_app.Controllers
{
    // [Authorize]//globally authorization
    public class CustomersController : Controller
    {
        
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //[Authorize]  // authorization only for Index action
        [Authorize]
        // GET: Customers
        public ActionResult Index()
        {
            //The below code is consuming webapi in mvc controller to get all customers

            IEnumerable<Customer> customers;

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Customers").Result;
            customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result; return View(customers);
        }
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
        

        public ActionResult Details(int id)
        {
            //line no 44 -47 is display  customer without WebApi.....

            //var singleCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //if (singleCustomer == null)
            //    return HttpNotFound();
            //return View(singleCustomer);


            //========Below code is displaying single customer with API=======
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync($"Customers/{id}").Result;
            Customer singlecust;
            singlecust = response.Content.ReadAsAsync<Customer>().Result;
            return View(singlecust);



        }
        [HttpGet]
        public ActionResult New()  //display the form
        {
            //var membershipTypes = _context.MembershipTypes.ToList();
            //var viewModel = new NewCustomerViewModel
            //{
            //    MembershipTypes = membershipTypes
            //};
            //return View(viewModel);

            //========Below code is displaying  customer with API=======

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Membership").Result;
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = response.Content.ReadAsAsync<IEnumerable<MembershipType>>().Result
            };
            return View(viewModel);


        }


        //[HttpPost]
        //public ActionResult Create(Customer customer)  //submit the form,parameter is of model
        //                                               //must have parameter in Post method      //Its called Model Binding
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Customers");//Back to customer controller page
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustomerViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.MembershipTypes.ToList()
            //    };
            //    return View("New", viewModel);
            //}
            //if (customer.Id == 0)
            //    _context.Customers.Add(customer);
            //else
            //{
            //    var customerInDb = _context.Customers.Single(p => p.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.DOB = customer.DOB;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //}
            //****************************With API****************
            if (customer.Id == 0)
            {
                HttpResponseMessage cust = GlobalVariables.webApiClient.PostAsJsonAsync("Customers", customer).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage cust1 = GlobalVariables.webApiClient.PutAsJsonAsync("Customers?id=" + customer.Id.ToString(), customer).Result;
                return RedirectToAction("Index");
            }

        }
        public ActionResult Edit(int id)
        {
            //var updateCast = _context.Customers.SingleOrDefault(c => c.Id == id);
            //if (updateCast == null)
            //{
            //    return HttpNotFound();
            //}
            //var vm = new NewCustomerViewModel
            //{
            //    Customer = updateCast,
            //    MembershipTypes = _context.MembershipTypes.ToList()
            //};
            //return View("New",vm);

            //==========================With API=============================
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Membership").Result;
            HttpResponseMessage cust = GlobalVariables.webApiClient.GetAsync("Customers?id=" + id.ToString()).Result;
            Customer customers = cust.Content.ReadAsAsync<Customer>().Result;
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customers,
                MembershipTypes = response.Content.ReadAsAsync<IEnumerable<MembershipType>>().Result
            };
            return View("New", viewmodel);

        }




        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customerTbl = _context.Customers.Find(id);
            _context.Customers.Remove(customerTbl);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }





        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}