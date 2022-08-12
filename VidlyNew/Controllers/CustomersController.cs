using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
   
    public class CustomersController : Controller
    {
        // untuk akses database perlu kontex
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost] ////untuk memodifikasi data usahakan jgn GET
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ///jika tidak valid akan mengembalikan bentuk form kembali
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                ////kalau kosong lempar exception, klo singledefault lempar null
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

                ///atau bisa pake mapper(karena untuk menghindari issue security yg bisa melakukan update  map tidak digunakan)
                //Mapper.Map(customer,customerInDb);

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = cus,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm",viewModel);
        }

    
        public ActionResult Index()
        {
            //var customer = GetCustomers(); ////ambil data tanpa database

            //var customer = _context.Customers.Include(c=> c.MembershipType).ToList(); ///SUDAH DILEMPAR DENGAN API
            // return View(customer); ///SUDAH DILEMPAR DENGAN API
            return View();
        }

        public ActionResult Details(int id)
        {
          //  var cus = GetCustomers().SingleOrDefault(c => c.Id == id); //tanpa database
            var cus = _context.Customers.Include(d=> d.MembershipType).SingleOrDefault(c=> c.Id == id);
            if (cus == null)
                return HttpNotFound();
            return View(cus);
        }

        //////method tanpa database
        //    public IEnumerable<Customer> GetCustomers()
        //  {
        //  return new List<Customer>
        //  {
        //    new Customer{ Name="Willy Wonka",Id =1},
        //     new Customer{ Name="Tommy Parker",Id =2},
        ///     new Customer{ Name="Tony Stark", Id=3}
        //   };
        // }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}