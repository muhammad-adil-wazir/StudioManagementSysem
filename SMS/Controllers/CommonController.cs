using SMS.Common;
using SMS.DataContext.Entities;
using SMS.DBAccess;
using SMS.Filter;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class CommonController : Controller
    {

        private UnitOfWork _uow;
        public CommonController(UnitOfWork uow)
        {
            _uow = uow;
        }
        public ActionResult IsNameExists(string Name, string Entity, int ID = 0)
        {
            var _tableName = Entity;
            if (!Entity.Contains("Status"))
            {
                _tableName = Entity + "s";
            }
            if(Entity.IndexOf('y') == Entity.Length - 1)
            {
                _tableName = Entity.Substring(0, Entity.Length - 1) + "ies";
            }
            var _result = false;
            if (ID > 0)
            {
               var ds = DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS,"SELECT * FROM DBO." + _tableName + " WHERE ISDELETED='false' AND " + Entity + "ID !=" + ID + " AND LOWER(" + Entity + "Name)='" + Name + "'", new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                if(ds != null)
                {
                    if(ds.Tables.Count > 0)
                    {
                        if(ds.Tables[0].Rows.Count > 0)
                        {
                            _result = true;
                        }
                    }
                }
                //if (Entity == "status")
                //{
                //    if (_uow.Repository<BaseEntity>().Get(at => at.LeaveStatusName.Equals(Name.ToLower()) && at.LeaveStatusID != Id && at.IsDeleted == false).Count > 0)
                //    {
                //        _result = true;
                //    }
                //}
                //if (Entity == "type")
                //{
                //    if (_leaveTypeService.Get(at => at.LeaveTypeName.Equals(Name.ToLower()) && at.LeaveTypeID != Id && at.IsDeleted == false).Count > 0)
                //    {
                //        _result = true;
                //    }
                //}
                //if (Entity == "attendence")
                //{
                //    var _date = Name;
                //    var _day = Convert.ToInt32(_date.Split('/')[0]);
                //    var _month = Convert.ToInt32(_date.Split('/')[1]);
                //    var _year = Convert.ToInt32(_date.Split('/')[2]);
                //    var _leaveStatusID = "ApprovedLeaveStatusID".GetConfigByKey<int>();
                //    if (_leaveService.Get(at => (at.FromDate <= new DateTime(_year, _month, _day) && at.ToDate >= new DateTime(_year, _month, _day)) && at.EmployeeID == Id && at.IsDeleted == false && at.LeaveStatusID == _leaveStatusID).Count > 0)
                //    {
                //        _result = true;
                //    }
                //}
            }
            else
            {
                var ds = DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "SELECT * FROM DBO." + _tableName + " WHERE ISDELETED='false' AND LOWER(" + Entity + "Name)='" + Name + "'", new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _result = true;
                        }
                    }
                }
                //if (Entity == "status")
                //{
                //    if (_leaveStatusService.Get(at => at.LeaveStatusName.Equals(Name.ToLower()) && at.IsDeleted == false).Count > 0)
                //    {
                //        _result = true;
                //    }
                //}
                //if (Entity == "type")
                //{
                //    if (_leaveTypeService.Get(at => at.LeaveTypeName.Equals(Name.ToLower()) && at.IsDeleted == false).Count > 0)
                //    {
                //        _result = true;
                //    }
                //}
            }
            return Json( new { status = "success", data = _result },JsonRequestBehavior.AllowGet);
        }
        #region Nationality

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Nationality")]
        public ActionResult AllNationalities()
        {
            var _nationalities = _uow.Repository<Nationality>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.NationalityID).ToList();
            return View(_nationalities);
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Nationality")]
        public ActionResult NationalityDetails(int id)
        {
            var _nationality = _uow.Repository<Nationality>().Get(x => x.IsDeleted == false && x.NationalityID == id).ToList();
            return View(_nationality);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Nationality")]
        public ActionResult NationalityCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Nationality")]
        public ActionResult NationalityCreate(Nationality nationality)
        {
            try
            {
                nationality.CreatedByDate = DateTime.Now;
                nationality.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Nationality>().Insert(nationality);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        // GET: Employee/Edit/5
        public ActionResult NationalityEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Nationality")]
        public ActionResult NationalityEdit(Nationality nationality)
        {
            try
            {
                var _nationality = _uow.Repository<Nationality>().Get(x => x.NationalityID == nationality.NationalityID && x.IsDeleted == false).FirstOrDefault();
                _nationality.NationalityName = nationality.NationalityName;
                _nationality.Remarks = nationality.Remarks;
                _nationality.updatedByDate = DateTime.Now;
                _nationality.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Nationality>().Update(_nationality);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Nationality")]
        public ActionResult NationalityDelete(int id)
        {
            try
            {
                var _nationality = _uow.Repository<Nationality>().Get(x => x.NationalityID == id && x.IsDeleted == false).FirstOrDefault();
                _nationality.IsDeleted = true;
                _nationality.updatedByDate = DateTime.Now;
                _nationality.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Nationality>().Update(_nationality);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Bank

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Bank")]
        public ActionResult AllBanks()
        {
            var _banks = _uow.Repository<Bank>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.BankID).ToList();
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();

            return View(new BankComplexModel { Banks = _banks , Locations = _locations , Countries = _countries });
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Bank")]
        public ActionResult BankDetails(int id)
        {
            var _bank = _uow.Repository<Bank>().Get(x => x.IsDeleted == false && x.BankID == id).ToList();
            return View(_bank);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Bank")]
        public ActionResult BankCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Bank")]
        public ActionResult BankCreate(Bank bank)
        {
            try
            {
                bank.CreatedByDate = DateTime.Now;
                bank.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Bank>().Insert(bank);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult BankEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Bank")]
        public ActionResult BankEdit(Bank bank)
        {
            try
            {
                var _bank = _uow.Repository<Bank>().Get(x => x.BankID == bank.BankID && x.IsDeleted == false).FirstOrDefault();
                _bank.BankName = bank.BankName;
                _bank.BranchName = bank.BranchName;
                _bank.LocationID = bank.LocationID;
                _bank.CountryID = bank.CountryID;
                _bank.Address = bank.Address;
                _bank.ContactNumber = bank.ContactNumber;
                _bank.ContactPerson = bank.ContactPerson;
                _bank.Remarks = bank.Remarks;
                _bank.updatedByDate = DateTime.Now;
                _bank.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Bank>().Update(_bank);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Bank")]
        public ActionResult BankDelete(int id)
        {
            try
            {
                var _bank = _uow.Repository<Bank>().Get(x => x.BankID == id && x.IsDeleted == false).FirstOrDefault();
                _bank.IsDeleted = true;
                _bank.updatedByDate = DateTime.Now;
                _bank.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Bank>().Update(_bank);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region BankAccountType

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "BankAccountType")]
        public ActionResult AllBankAccountTypes()
        {
            var _bankAccountTypes = _uow.Repository<BankAccountType>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.BankAccountTypeID).ToList();
            return View(_bankAccountTypes);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "BankAccountType")]
        public ActionResult BankAccountTypeDetails(int id)
        {
            var _bankAccountType = _uow.Repository<BankAccountType>().Get(x => x.IsDeleted == false && x.BankAccountTypeID == id).ToList();
            return View(_bankAccountType);
        }

        // GET: Employee/Create
        public ActionResult BankAccountTypeCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "BankAccountType")]
        public ActionResult BankAccountTypeCreate(BankAccountType bankAccountType)
        {
            try
            {
                bankAccountType.CreatedByDate = DateTime.Now;
                bankAccountType.CreatedByID = CurrentUser.UserID;
                _uow.Repository<BankAccountType>().Insert(bankAccountType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "BankAccountType")]
        public ActionResult BankAccountTypeEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "BankAccountType")]
        public ActionResult BankAccountTypeEdit(BankAccountType bankAccountType)
        {
            try
            {
                var _bankAccountType = _uow.Repository<BankAccountType>().Get(x => x.BankAccountTypeID == bankAccountType.BankAccountTypeID && x.IsDeleted == false).FirstOrDefault();
                _bankAccountType.BankAccountTypeName = bankAccountType.BankAccountTypeName;
                _bankAccountType.Remarks = bankAccountType.Remarks;
                _bankAccountType.updatedByDate = DateTime.Now;
                _bankAccountType.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<BankAccountType>().Update(_bankAccountType);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "BankAccountType")]
        public ActionResult BankAccountTypeDelete(int id)
        {
            try
            {
                var _bankAccountType = _uow.Repository<BankAccountType>().Get(x => x.BankAccountTypeID == id && x.IsDeleted == false).FirstOrDefault();
                _bankAccountType.IsDeleted = true;
                _bankAccountType.updatedByDate = DateTime.Now;
                _bankAccountType.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<BankAccountType>().Update(_bankAccountType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Religion

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Country")]
        public ActionResult AllReligions()
        {
            var _religions = _uow.Repository<Religion>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.ReligionID).ToList();
            return View(_religions);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Country")]
        public ActionResult ReligionDetails(int id)
        {
            var _religion = _uow.Repository<Religion>().Get(x => x.IsDeleted == false && x.ReligionID == id).ToList();
            return View(_religion);
        }

        // GET: Employee/Create
        public ActionResult ReligionCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Country")]
        public ActionResult ReligionCreate(Religion religion)
        {
            try
            {
                religion.CreatedByDate = DateTime.Now;
                religion.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Religion>().Insert(religion);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult ReligionEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Country")]
        public ActionResult ReligionEdit(Religion religion)
        {
            try
            {
                var _religion = _uow.Repository<Religion>().Get(x => x.ReligionID == religion.ReligionID && x.IsDeleted == false).FirstOrDefault();
                _religion.ReligionName = religion.ReligionName;
                _religion.Remarks = religion.Remarks;
                _religion.updatedByDate = DateTime.Now;
                _religion.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Religion>().Update(_religion);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Country")]
        public ActionResult ReligionDelete(int id)
        {
            try
            {
                var _religion = _uow.Repository<Religion>().Get(x => x.ReligionID == id && x.IsDeleted == false).FirstOrDefault();
                _religion.IsDeleted = true;
                _religion.updatedByDate = DateTime.Now;
                _religion.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Religion>().Update(_religion);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Country

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Country")]
        public ActionResult AllCountries()
        {
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.CountryID).ToList();
            return View(_countries);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        public ActionResult CountryDetails(int id)
        {
            var _country = _uow.Repository<Country>().Get(x => x.IsDeleted == false && x.CountryID == id).ToList();
            return View(_country);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Country")]
        public ActionResult CountryCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Country")]
        public ActionResult CountryCreate(Country country)
        {
            try
            {
                country.CreatedByDate = DateTime.Now;
                country.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Country>().Insert(country);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Country")]
        public ActionResult CountryEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Country")]
        public ActionResult CountryEdit(Country country)
        {
            try
            {
                var _country = _uow.Repository<Country>().Get(x => x.CountryID == country.CountryID && x.IsDeleted == false).FirstOrDefault();
                _country.CountryName = country.CountryName;
                _country.Remarks = country.Remarks;
                _country.updatedByDate = DateTime.Now;
                _country.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Country>().Update(_country);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Country")]
        public ActionResult CountryDelete(int id)
        {
            try
            {
                var _country = _uow.Repository<Country>().Get(x => x.CountryID == id && x.IsDeleted == false).FirstOrDefault();
                _country.IsDeleted = true;
                _country.updatedByDate = DateTime.Now;
                _country.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Country>().Update(_country);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Location

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Location")]
        public ActionResult AllLocations()
        {
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.LocationID).ToList();
            return View(_locations);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Location")]
        public ActionResult LocationDetails(int id)
        {
            var _location = _uow.Repository<Location>().Get(x => x.IsDeleted == false && x.LocationID == id).ToList();
            return View(_location);
        }

        // GET: Employee/Create
        public ActionResult LocationCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Location")]
        public ActionResult LocationCreate(Location location)
        {
            try
            {
                location.CreatedByDate = DateTime.Now;
                location.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Location>().Insert(location);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Location")]
        public ActionResult LocationEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Location")]
        public ActionResult LocationEdit(Location location)
        {
            try
            {
                var _location = _uow.Repository<Location>().Get(x => x.LocationID == location.LocationID && x.IsDeleted == false).FirstOrDefault();
                _location.LocationName = location.LocationName;
                _location.Remarks = location.Remarks;
                _location.updatedByDate = DateTime.Now;
                _location.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Location>().Update(_location);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Location")]
        public ActionResult LocationDelete(int id)
        {
            try
            {
                var _location = _uow.Repository<Location>().Get(x => x.LocationID == id && x.IsDeleted == false).FirstOrDefault();
                _location.IsDeleted = true;
                _location.updatedByDate = DateTime.Now;
                _location.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Location>().Update(_location);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Shift

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Shift")]
        public ActionResult AllShifts()
        {
            var _shifts = _uow.Repository<Shift>().Get(x => x.IsDeleted == false).ToList();
            return View(_shifts);
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Shift")]
        public ActionResult ShiftDetails(int id)
        {
            var _shift = _uow.Repository<Shift>().Get(x => x.IsDeleted == false && x.ShiftID == id).ToList();
            return View(_shift);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Shift")]
        public ActionResult ShiftCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Shift")]
        public ActionResult ShiftCreate(Shift shift)
        {
            try
            {
                shift.CreatedByDate = DateTime.Now;
                shift.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Shift>().Insert(shift);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Shift")]
        public ActionResult ShiftEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5

        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Shift")]
        public ActionResult ShiftEdit(Shift shift)
        {
            try
            {
                var _shift = _uow.Repository<Shift>().Get(x => x.ShiftID == shift.ShiftID && x.IsDeleted == false).FirstOrDefault();
                _shift.ShiftName = shift.ShiftName;
                _shift.BreakEndTime = shift.BreakEndTime;
                _shift.BreakStartTime = shift.BreakStartTime;
                _shift.EndTime = shift.EndTime;
                _shift.StartTime = shift.StartTime;
                _shift.TotalBreakHours = shift.TotalBreakHours;
                _shift.TotalTime = shift.TotalTime;
                _shift.TotalWorkingHours = shift.TotalWorkingHours;
                _shift.Remarks = shift.Remarks;
                _shift.updatedByDate = DateTime.Now;
                _shift.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Shift>().Update(_shift);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Shift")]
        public ActionResult ShiftDelete(int id)
        {
            try
            {
                var _shift = _uow.Repository<Shift>().Get(x => x.ShiftID == id && x.IsDeleted == false).OrderByDescending(x => x.ShiftID).ToList().FirstOrDefault();
                _shift.IsDeleted = true;
                _shift.updatedByDate = DateTime.Now;
                _shift.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Shift>().Update(_shift);
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