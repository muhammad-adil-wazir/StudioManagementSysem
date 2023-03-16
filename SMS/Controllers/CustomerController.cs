using SMS.Common;
using SMS.DataContext.Entities;
using SMS.DBAccess;
using SMS.Filter;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private UnitOfWork _uow;
        public CustomerController(UnitOfWork uow)
        {
            _uow = uow;
        }
        //public CustomerController()
        //{
        //}
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Customer")]
        public ActionResult AllCustomers()
        {
            var _customers = _uow.Repository<Customer>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.CustomerID).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).ToList();
            return View(new CustomerComplexModel { Countries = _countries, Customers = _customers, Locations = _locations });
            //return View(new List<Customer>() { new Customer { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Customer")]
        public ActionResult Details(int id)
        {
            var _customer = _uow.Repository<Customer>().Get(x => x.IsDeleted == false && x.CustomerID == id).ToList();
            return View(_customer);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Customer")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Customer")]
        public ActionResult Create(Customer customer)
        {
            try
            {
                customer.CreatedByDate = DateTime.Now;
                customer.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Customer>().Insert(customer);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Customer")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Customer")]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var _customer = _uow.Repository<Customer>().Get(x => x.CustomerID == customer.CustomerID && x.IsDeleted == false).FirstOrDefault();
                _customer.CustomerName = customer.CustomerName;
                _customer.Address = customer.Address;
                _customer.CountryID = customer.CountryID;
                _customer.Email = customer.Email;
                _customer.LocationID = customer.LocationID;
                _customer.MobileNumber = customer.MobileNumber;
                _customer.PhoneNumber = customer.PhoneNumber;
                _customer.Remarks = customer.Remarks;
                _uow.Repository<Customer>().Update(_customer);
                _uow.SaveChanges();
                return Json( new { status = "success"});
            }
            catch(Exception ex)
            {
                return Json(new { status = "success" , error = ex.Message });
            }
            
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Customer")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _customer = _uow.Repository<Customer>().Get(x => x.CustomerID == id && x.IsDeleted == false).FirstOrDefault();
                _customer.updatedByDate = DateTime.Now;
                _customer.UpdatedByID = CurrentUser.UserID;
                _customer.IsDeleted = true;
                _uow.Repository<Customer>().Update(_customer);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
    }
}