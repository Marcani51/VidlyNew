using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Data.Entity;
using VidlyNew.Models;
using VidlyNew.Dtos;
using AutoMapper;

namespace VidlyNew.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /API/Customers
        public IHttpActionResult GetCustomers(string query = null)//optional bisa null
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(m=>m.MembershipType)
                .SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) //// melakukan pengecekan request
                throw new HttpResponseException (HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+ "/" + customer.Id),customerDto);

        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c=> c.Id == id);  ////melakukan pengecekan data di database
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb); ///kalau sudah ada object sebelumnya bisa dijadikan arg 2, berbeda dengan create customer
           
            // kalau sudah pakai mapper tidak perlu pakai yg dibwah ini
            // customerInDb.Name = customer.Name;
           // customerInDb.BirthDay = customer.BirthDay;
           // customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
           // customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            return Ok();
        }

        // Delete /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);  ////melakukan pengecekan data di database
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
