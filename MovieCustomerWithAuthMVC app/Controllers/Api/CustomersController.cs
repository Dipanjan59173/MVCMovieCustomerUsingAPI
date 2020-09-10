using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Newtonsoft.Json.Linq;

namespace MovieCustomerMvcAppWithAuthen.Controllers.Api
{



    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return customers;
            //return _context.Customer.
            if(customers== null)
            {
                return NotFound();
            }
            return Ok(customers);
        }





        public IHttpActionResult GetCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok(customer);
            
        }
        //POST /api/customers
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest("Model data invalid");
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }





        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest(" Invalid Data");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
               // throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.DOB = customer.DOB;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.ISSubscribedToNewsLetter = customer.ISSubscribedToNewsLetter;
            _context.SaveChanges();
            return Ok();





        }
        //DELETE /api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("Not A valid Customer id");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            
           // if (customerInDb == null)
              //  throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }





    }
}
