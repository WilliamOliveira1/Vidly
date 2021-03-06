using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Dtos;
using Vidly1.Models;
using System.Data.Entity;


namespace Vidly1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        /// <summary>
        /// GET /api/cutomers
        /// </summary>
        /// <returns>List of customers</returns>
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        /// <summary>
        /// GET /api/customers/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return single customer</returns>
        public IHttpActionResult GetCustomer(int id)
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        /// <summary>
        /// POST /api/customers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>customer data changed</returns>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        /// <summary>
        /// PUT /api/customers/
        /// </summary>
        /// <param name="id">id from customer that will be updated</param>
        /// <param name="customerDto">data from customer that will be updated</param>
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        ///  DELETE /api/customers/1
        /// </summary>
        /// <param name="id">id from the customer that will be deleted</param>
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
