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
    public class CompanyController : Controller
    {
        #region Company
        private UnitOfWork _uow;
        public CompanyController(UnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Company")]
        public ActionResult AllCompanies()
        {
            var _companies = _uow.Repository<Company>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.CompanyID).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).ToList();
            return View(new CompanyComplexModel { Countries = _countries, Companies = _companies, Locations = _locations });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Company")]
        public ActionResult Details(int id)
        {
            var _company = _uow.Repository<Company>().Get(x => x.IsDeleted == false && x.CompanyID == id).ToList();
            return View(_company);
        }

        // GET: Employee/Create
        public ActionResult CompanyCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
       
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Company")]
        public ActionResult Create(Company company)
        {
            try
            {
                //var image = Request.Files["LogoFile"];
                var image = Utilities.LoadImage(company.Logo.Substring((company.Logo.IndexOf(',') + 1)));
                var imageName = company.CompanyName + "(" + company.CompanyID + ")" + ".jpg";
                image.Save(Server.MapPath("~/Content/Images/CompanyLogo/" + imageName));
                company.Logo = imageName;
                company.CreatedByDate = DateTime.Now;
                company.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Company>().Insert(company);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Company")]
        public ActionResult CompanyEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Company")]
        public ActionResult Edit(Company company)
        {
            try
            {
                var _company = _uow.Repository<Company>().Get(x => x.CompanyID == company.CompanyID && x.IsDeleted == false).FirstOrDefault();
                var imageName = "";
                //var image = Request.Files["LogoFile"];
                if (company.Logo != null)
                {
                    var image = Utilities.LoadImage(company.Logo.Substring((company.Logo.IndexOf(',') + 1)));
                    imageName = company.CompanyName + "(" + company.CompanyID + ")" + ".jpg";
                    image.Save(Server.MapPath("~/Content/Images/CompanyLogo/" + imageName));
                    _company.Logo = imageName;
                }
                _company.CompanyName = company.CompanyName;
                _company.ParentCompanyID = company.ParentCompanyID;
                _company.EstablishedBy = company.EstablishedBy;
                _company.EstablishmentDate = company.EstablishmentDate;
                _company.AssistedBy = company.AssistedBy;
                _company.RegistrationID = company.RegistrationID;
                _company.CountryID = company.CountryID;
                _company.LocationID = company.LocationID;
                _company.CompanyNumber = company.CompanyNumber;
                _company.Currency = company.Currency;
                _company.Address = company.Address;
                _company.CompanyStatusID = company.CompanyStatusID;
                _company.CompanyTypeID = company.CompanyTypeID;
                _company.ContactPerson = company.ContactPerson;
                _company.MobileNumber = company.MobileNumber;
                _company.OfficeNumber = company.OfficeNumber;
                _company.TotalCapital = company.TotalCapital;
                _company.TotalShares = company.TotalShares;
                _company.InitialValue = company.InitialValue;
                _company.CurrentValue = company.CurrentValue;
                _company.Remarks = company.Remarks;
                _company.updatedByDate = DateTime.Now;
                _company.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Company>().Update(_company);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }


        // POST: Employee/Delete/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Company")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _company = _uow.Repository<Company>().Get(x => x.CompanyID == id && x.IsDeleted == false).FirstOrDefault();
                _company.IsDeleted = true;
                _company.updatedByDate = DateTime.Now;
                _company.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Company>().Update(_company);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion
    }
}