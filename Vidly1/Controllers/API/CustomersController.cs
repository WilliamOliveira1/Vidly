using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Dtos;
using Vidly1.Models;

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
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        /// <summary>
        /// POST /api/customers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>customer data changed</returns>
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        /// <summary>
        /// PUT /api/customers/
        /// </summary>
        /// <param name="id">id from customer that will be updated</param>
        /// <param name="customerDto">data from customer that will be updated</param>
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        /// <summary>
        ///  DELETE /api/customers/1
        /// </summary>
        /// <param name="id">id from the customer that will be deleted</param>
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
