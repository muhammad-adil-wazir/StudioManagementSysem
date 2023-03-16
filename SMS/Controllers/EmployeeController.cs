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
    public class EmployeeController : Controller
    {
        private UnitOfWork _uow;
        public EmployeeController(UnitOfWork uow)
        {
            _uow = uow;
        }
       
        #region Employee

        // GET: Employee
        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Employee")]
        public ActionResult AllEmployees()
        {
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.EmployeeID).ToList();
            var _designations = _uow.Repository<Designation>().Get(x => x.IsDeleted == false).ToList();
            var _departments = _uow.Repository<Department>().Get(x => x.IsDeleted == false).ToList();
            var _shifts = _uow.Repository<Shift>().Get(x => x.IsDeleted == false).ToList();
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false).ToList();
            var _empSkills = _uow.Repository<EmployeeSkillDetail>().Get(x => x.IsDeleted == false)
                .Select(x=> new EmployeeSkillDetail { EmployeeID = x.EmployeeID, SkillID = x.SkillID,EmployeeSkillDetailID = x.EmployeeSkillDetailID }).ToList();
            var _banks = _uow.Repository<Bank>().Get(x => x.IsDeleted == false).ToList();
            var _bankAcountTypes = _uow.Repository<BankAccountType>().Get(x => x.IsDeleted == false).ToList();
            var _nationalities = _uow.Repository<Nationality>().Get(x => x.IsDeleted == false).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();
            var _companies = _uow.Repository<Company>().Get(x => x.IsDeleted == false).ToList();
            return View(new EmployeeComplexModel { Employees = _employees, BankAccountTypes = _bankAcountTypes, Banks = _banks, Companies = _companies, Departments = _departments, Designations = _designations, Nationalities = _nationalities, Shifts = _shifts, Countries = _countries,
            EmployeeSkills  = _empSkills, Skills = _skills});
            //return View(new List<Employee>() { new Employee { } });
        }

        // GET: Employee/Details/5
        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Employee")]
        public ActionResult Details(int id)
        {
            var _employee = _uow.Repository<Employee>().Get(x => x.IsDeleted == false && x.EmployeeID == id).ToList();
            return View(_employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Employee")]
        public ActionResult Create(Employee employee,string EmployeeSkills)
        {
            try
            {
                if(employee.PhotoPath != null)
                {
                    var image = Utilities.LoadImage(employee.PhotoPath.Substring((employee.PhotoPath.IndexOf(',') + 1)));
                    var imageName = employee.EmployeeName + "(" + employee.EmployeeID + ")" + ".jpg";
                    image.Save(Server.MapPath("~/Content/Images/EmployeeImages/" + imageName));
                    employee.PhotoPath = imageName;
                }
                if(employee.Gender == null || employee.Gender == "")
                {
                    employee.Gender = "male";
                }
                employee.CreatedByDate = DateTime.Now;
                employee.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Employee>().Insert(employee);
                _uow.SaveChanges();
                var _employeeSkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeSkillDetail>>(EmployeeSkills);
                for (int i = 0; i < _employeeSkills.Count; i++)
                {
                    _employeeSkills[i].EmployeeID = employee.EmployeeID;
                }
                _uow.Repository<EmployeeSkillDetail>().InsertList(_employeeSkills);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Employee")]
        public ActionResult Edit(Employee employee, string EmployeeSkills)
        {
            try
            {
                var _employee = _uow.Repository<Employee>().Get(x => x.EmployeeID == employee.EmployeeID && x.IsDeleted == false).FirstOrDefault();
                var imageName = "";
                if (employee.PhotoPath != null)
                {

                    var image = Utilities.LoadImage(employee.PhotoPath.Substring((employee.PhotoPath.IndexOf(',') + 1)));
                    imageName = employee.EmployeeName + "(" + employee.EmployeeID + ")" + ".jpg";
                    image.Save(Server.MapPath("~/Content/Images/EmployeeImages/" + imageName));
                    _employee.PhotoPath = imageName;
                }
                _employee.EmployeeID = employee.EmployeeID;
                _employee.AttendenceReferenceID = employee.AttendenceReferenceID;
                _employee.EmployeeName = employee.EmployeeName;
                _employee.BankID = employee.BankID;
                _employee.CompanyID = employee.CompanyID;
                _employee.ShiftID = employee.ShiftID;
                _employee.DesignationID = employee.DesignationID;
                _employee.ReportingToID = employee.ReportingToID;
                _employee.DepartmentID = employee.DepartmentID;
                _employee.WeeklyOff = employee.WeeklyOff;
                _employee.QualificationDescription = employee.QualificationDescription;
                _employee.PhoneNumber = employee.PhoneNumber;
                _employee.MobileNumber = employee.MobileNumber;
                _employee.FamilyContactNumber = employee.FamilyContactNumber;
                _employee.ContactPersonName = employee.ContactPersonName;
                _employee.Address = employee.Address;
                _employee.ContactPersonRelationship = employee.ContactPersonRelationship;
                _employee.NationalityID = employee.NationalityID;
                _employee.CountryID = employee.CountryID;
                _employee.RegionID = employee.RegionID;
                _employee.Gender = employee.Gender;
                _employee.Email = employee.Email;
                _employee.DOB = employee.DOB;
                _employee.ActualDOB = employee.ActualDOB;
                _employee.InternationalContactNumber = employee.InternationalContactNumber;
                _employee.PhotoPath = employee.PhotoPath;
                _employee.Status = employee.Status;
                _employee.MedicalHistory = employee.MedicalHistory;
                _employee.LeaveBalance = employee.LeaveBalance;
                _employee.AccountNumber = employee.AccountNumber;
                _employee.updatedByDate = DateTime.Now;
                _employee.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Employee>().Update(_employee);
                var _employeeSkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeSkillDetail>>(EmployeeSkills);
                for (int i = 0; i < _employeeSkills.Count; i++)
                {
                    _employeeSkills[i].EmployeeID = employee.EmployeeID;
                }
                DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "delete from EmployeeSkillDetails where EmployeeID =" + employee.EmployeeID , new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                _uow.Repository<EmployeeSkillDetail>().InsertList(_employeeSkills);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Employee")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _employee = _uow.Repository<Employee>().Get(x => x.EmployeeID == id && x.IsDeleted == false).FirstOrDefault();
                _employee.updatedByDate = DateTime.Now;
                _employee.UpdatedByID = CurrentUser.UserID;
                _employee.IsDeleted = true;
                _uow.Repository<Employee>().Update(_employee);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Designation

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Designation")]
        public ActionResult AllDesignations()
        {
            var _designations = _uow.Repository<Designation>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.DesignationID).ToList();
            return View(_designations);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Designation")]
        public ActionResult DesignationDetails(int id)
        {
            var _designation = _uow.Repository<Designation>().Get(x => x.IsDeleted == false && x.DesignationID == id).ToList();
            return View(_designation);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Designation")]
        public ActionResult DesignationCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Designation")]
        public ActionResult DesignationCreate(Designation designation)
        {
            try
            {
                designation.CreatedByDate = DateTime.Now;
                designation.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Designation>().Insert(designation);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Designation")]
        public ActionResult DesignationEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Designation")]
        public ActionResult DesignationEdit(Designation designation)
        {
            try
            {
                var _designation = _uow.Repository<Designation>().Get(x => x.DesignationID == designation.DesignationID && x.IsDeleted == false).FirstOrDefault();
                _designation.DesignationName = designation.DesignationName;
                _designation.Remarks = designation.Remarks;
                _designation.updatedByDate = DateTime.Now;
                _designation.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Designation>().Update(_designation);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Designation")]
        public ActionResult DesignationDelete(int id)
        {
            try
            {
                var _designation = _uow.Repository<Designation>().Get(x => x.DesignationID == id && x.IsDeleted == false).FirstOrDefault();
                _designation.IsDeleted = true;
                _designation.updatedByDate = DateTime.Now;
                _designation.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Designation>().Update(_designation);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Department

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Department")]
        public ActionResult AllDepartments()
        {
            var _departments = _uow.Repository<Department>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.DepartmentID).ToList();
            return View(_departments);
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Department")]
        public ActionResult DepartmentDetails(int id)
        {
            var _department = _uow.Repository<Department>().Get(x => x.IsDeleted == false && x.DepartmentID == id).ToList();
            return View(_department);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Department")]
        public ActionResult DepartmentCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Department")]
        public ActionResult DepartmentCreate(Department department)
        {
            try
            {
                department.CreatedByDate = DateTime.Now;
                department.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Department>().Insert(department);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult DepartmentEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Department")]
        public ActionResult DepartmentEdit(Department department)
        {
            try
            {
                var _department = _uow.Repository<Department>().Get(x => x.DepartmentID == department.DepartmentID && x.IsDeleted == false).FirstOrDefault();
                _department.DepartmentName = department.DepartmentName;
                _department.Remarks = department.Remarks;
                _department.updatedByDate = DateTime.Now;
                _department.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Department>().Update(_department);
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
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Department")]
        public ActionResult DepartmentDelete(int id)
        {
            try
            {
                var _department = _uow.Repository<Department>().Get(x => x.DepartmentID == id && x.IsDeleted == false).FirstOrDefault();
                _department.IsDeleted = true;
                _department.updatedByDate = DateTime.Now;
                _department.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Department>().Update(_department);
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
