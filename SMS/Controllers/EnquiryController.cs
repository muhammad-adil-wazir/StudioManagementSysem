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
    public class EnquiryController : Controller
    {
        // GET: Equiry
        private UnitOfWork _uow;
        public EnquiryController(UnitOfWork uow)
        {
            _uow = uow;
        }
        public EnquiryController()
        {
        }

        #region Enquiry
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Enquiry")]
        public ActionResult AllEnquiries()
        {
            var _enquiryStaus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false);
            var _enquiryTypes = _uow.Repository<EnquiryType>().Get(x => x.IsDeleted == false);
            var _devices = _uow.Repository<Device>().Get(x => x.IsDeleted == false);
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false)
                .Select(e=> new Employee { EmployeeID = e.EmployeeID, EmployeeName=e.EmployeeName }).ToList();
            var _employeeSkillDetails = _uow.Repository<EmployeeSkillDetail>().Get(x => x.IsDeleted == false)
                .Select(x=> new EmployeeSkillDetail { EmployeeID = x.EmployeeID, SkillID = x.SkillID, EmployeeSkillDetailID = x.EmployeeSkillDetailID }).ToList();
            var _customers = _uow.Repository<Customer>().Get(x => x.IsDeleted == false);
            //var _jobs = _uow.Repository<Job>().Get(x => x.IsDeleted == false);
            var _functionTypes = _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false);
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false);
            var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false).OrderByDescending(x=>x.EnquiryDate).ToList();
            var _enquiry = _enquiries.OrderByDescending(x => x.EnquiryID).FirstOrDefault();
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();
            var _enquiryID = 0;
            if (_enquiry != null)
            {
                _enquiryID = _enquiry.EnquiryID + 1;
            }
            return View(new EnquiryComplexModel { Employees = _employees, EmployeeSkills = _employeeSkillDetails, Customers = _customers, Devices = _devices, Enquiries = _enquiries, EnquiryStatus = _enquiryStaus, EnquiryTypes = _enquiryTypes, FunctionTypes = _functionTypes, Skills = _skills,
                   Enquiry = new Enquiry { EnquiryID = _enquiryID, EnquiryTime = DateTime.Now.TimeOfDay, EnquiryDate = DateTime.Now , FunctionDate = DateTime.Now },
                   CustomerModel = new CustomerComplexModel { Countries = _countries, Locations = _locations ,Customers = _customers }
            });
        }


        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Enquiry")]
        public ActionResult Details(int id)
        {
            //var _enquiry = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false && x.EnquiryID == id).FirstOrDefault();
            var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false);
            var _enquiryTypes = _uow.Repository<EnquiryType>().Get(x => x.IsDeleted == false);
            var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.EnquiryDate).ToList();
            var _enquiry = _enquiries.FirstOrDefault(x=>x.EnquiryID == id);
            var _enquiryDevices = _uow.Repository<EnquiryDeviceDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID)
                .Select(x=> new EnquiryDeviceDetail{ EnquiryID = x.EnquiryID,DeviceID = x.DeviceID, HiredCost = x.HiredCost, FromDate = x.FromDate, IsHired = x.IsHired, Quantity =x.Quantity, ToDate = x.ToDate, EnquiryDeviceDetailID = x.EnquiryDeviceDetailID  }).ToList();
            var _enquiryEmployees = _uow.Repository<EnquiryEmpDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID)
                .Select(x => new EnquiryEmpDetail { EnquiryID = x.EnquiryID,EmployeeName = x.EmployeeName,CompanyName = x.CompanyName, EmployeeID = x.EmployeeID, SkillID = x.SkillID, EnquiryEmpDetailID = x.EnquiryEmpDetailID,HiredCost=x.HiredCost,IsHired=x.IsHired,FromDate=x.FromDate,ToDate=x.ToDate }).ToList();
            //var _enquiryJobs = _uow.Repository<EnquiryJobDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID).Select(x => new EnquiryJobDetail { EnquiryID = x.EnquiryID, JobID = x.JobID }).ToList();
            //var _enquirySkills = _uow.Repository<EnquirySkillDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID)
            //.Select(x => new EnquirySkillDetail { EnquiryID = x.EnquiryID, SkillID = x.SkillID, HiredCost = x.HiredCost, IsHired = x.IsHired, Quantity = x.Quantity, EnquirySkillDetailID = x.EnquirySkillDetailID }).ToList();
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false)
                .Select(e => new Employee { EmployeeID = e.EmployeeID, EmployeeName = e.EmployeeName }).ToList();
            var _employeeSkillDetails = _uow.Repository<EmployeeSkillDetail>().Get(x => x.IsDeleted == false)
                .Select(x => new EmployeeSkillDetail { EmployeeID = x.EmployeeID, SkillID = x.SkillID, EmployeeSkillDetailID = x.EmployeeSkillDetailID }).ToList();

            var _devices = _uow.Repository<Device>().Get(x => x.IsDeleted == false);
            var _customers = _uow.Repository<Customer>().Get(x => x.IsDeleted == false).ToList();
            //var _jobs = _uow.Repository<Job>().Get(x => x.IsDeleted == false);
            var _functionTypes = _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false);
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false);
            var _locations = _uow.Repository<Location>().Get(x => x.IsDeleted == false).ToList();
            var _countries = _uow.Repository<Country>().Get(x => x.IsDeleted == false).ToList();
            return View("AllEnquiries", new EnquiryComplexModel { Customers = _customers, Devices = _devices, Enquiries = _enquiries, EnquiryStatus = _enquiryStatus, EnquiryTypes = _enquiryTypes,
                FunctionTypes = _functionTypes, Skills = _skills , EnquiryDevices = _enquiryDevices ,
                EnquiryEmployees = _enquiryEmployees, Employees = _employees,EmployeeSkills = _employeeSkillDetails, Enquiry = _enquiry,
                CustomerModel = new CustomerComplexModel { Countries = _countries, Locations = _locations, Customers = _customers }
            });
            //return View(_enquiry);
        }
        
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Enquiry")]
        public ActionResult Create(Enquiry enquiry,string EmployeeSkills, string EnquiryDevices, string EnquiryFunctionTypes, string EnquirySkills)
        {
            try
            {
                enquiry.CreatedByDate = DateTime.Now;
                enquiry.CreatedByID = CurrentUser.UserID;
                enquiry = _uow.Repository<Enquiry>().Insert(enquiry);
                _uow.SaveChanges();
                //var _enquiryFunctionTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryFunctionTypeDetail>>(EnquiryFunctionTypes);
                var _enquiryEmployees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryEmpDetail>>(EmployeeSkills);
                //var _enquirySkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquirySkillDetail>>(EnquirySkills);
                var _enquiryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryDeviceDetail>>(EnquiryDevices);
                //for (int i = 0; i < _enquirySkills.Count; i++)
                //{
                //    _enquirySkills[i].EnquiryID = enquiry.EnquiryID;
                //}
                for (int i = 0; i < _enquiryEmployees.Count; i++)
                {
                    _enquiryEmployees[i].EnquiryID = enquiry.EnquiryID;
                }
                for (int i = 0; i < _enquiryDevices.Count; i++)
                {
                    _enquiryDevices[i].EnquiryID = enquiry.EnquiryID;
                }
                //for (int i = 0; i < _enquiryFunctionTypes.Count; i++)
                //{
                //    _enquiryFunctionTypes[i].EnquiryID = enquiry.EnquiryID;
                //}
                _uow.Repository<EnquiryStatusDetail>().Insert(new EnquiryStatusDetail { EnquiryID = enquiry.EnquiryID , EnquiryStatusID = enquiry.EnquiryStatusID });
                _uow.Repository<EnquiryEmpDetail>().InsertList(_enquiryEmployees);
                //_uow.Repository<EnquiryJobDetail>().InsertList(_enquiryJobs);
                _uow.Repository<EnquiryDeviceDetail>().InsertList(_enquiryDevices);
                //_uow.Repository<EnquiryFunctionTypeDetail>().InsertList(_enquiryFunctionTypes);
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
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Enquiry")]
        public ActionResult Edit(Enquiry enquiry, string EmployeeSkills, string EnquiryDevices, string EnquiryFunctionTypes, string EnquirySkills)
        {
            try
            {
                var _enquiry = _uow.Repository<Enquiry>().Get(x => x.EnquiryID == enquiry.EnquiryID && x.IsDeleted == false).FirstOrDefault();
                _enquiry.updatedByDate = DateTime.Now;
                _enquiry.UpdatedByID = CurrentUser.UserID;
                _enquiry.ChargeableCost = enquiry.ChargeableCost;
                _enquiry.CustomerID = enquiry.CustomerID;
                _enquiry.EnquiryDate = enquiry.EnquiryDate;
                _enquiry.EnquiryStatusID = enquiry.EnquiryStatusID;
                _enquiry.EnquiryTime = enquiry.EnquiryTime;
                _enquiry.EnquiryTypeID = enquiry.EnquiryTypeID;
                _enquiry.FunctionTypeID = enquiry.FunctionTypeID;
                _enquiry.FunctionDate = enquiry.FunctionDate;
                _enquiry.FunctionDate = enquiry.FunctionDate;
                _enquiry.MaxCost = enquiry.MaxCost;
                _enquiry.Venue = enquiry.Venue;
                _enquiry.MinCost = enquiry.MinCost;
                _enquiry.Reference = enquiry.Reference;
                _enquiry.Remarks = enquiry.Remarks;
                _uow.Repository<Enquiry>().Update(_enquiry);
                DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "delete from EnquiryEmpDetails where EnquiryID =" + enquiry.EnquiryID + "; delete from EnquiryJobDetails where EnquiryID =" + enquiry.EnquiryID + "; delete from EnquiryFunctionTypeDetails where EnquiryID =" + enquiry.EnquiryID + "; delete from EnquiryDeviceDetails where EnquiryID =" + enquiry.EnquiryID, new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                //var _enquiryFunctionTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryFunctionTypeDetail>>(EnquiryFunctionTypes);
                //var _enquiryJobs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryJobDetail>>(EnquiryJobs);
                var _enquiryEmployees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryEmpDetail>>(EmployeeSkills);
                //var _enquirySkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquirySkillDetail>>(EnquirySkills);
                var _enquiryDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryDeviceDetail>>(EnquiryDevices);
                for (int i = 0; i < _enquiryEmployees.Count; i++)
                {
                    _enquiryEmployees[i].EnquiryID = enquiry.EnquiryID;
                }
                for (int i = 0; i < _enquiryDevices.Count; i++)
                {
                    _enquiryDevices[i].EnquiryID = _enquiry.EnquiryID;
                }
                _uow.Repository<EnquiryStatusDetail>().Insert(new EnquiryStatusDetail { EnquiryID = enquiry.EnquiryID, EnquiryStatusID = enquiry.EnquiryStatusID });
                _uow.Repository<EnquiryEmpDetail>().InsertList(_enquiryEmployees);
                _uow.Repository<EnquiryDeviceDetail>().InsertList(_enquiryDevices);
                _uow.SaveChanges();
                return Json(new { status = "success", returnUrl = "../Enquiry/AllEnquiries" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        // POST: Employee/Delete/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Enquiry")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _enquiry = _uow.Repository<Enquiry>().Get(x => x.EnquiryID == id && x.IsDeleted == false).FirstOrDefault();
                _enquiry.updatedByDate = DateTime.Now;
                _enquiry.UpdatedByID = CurrentUser.UserID;
                _enquiry.IsDeleted = true;
                _uow.Repository<Enquiry>().Update(_enquiry);
                _uow.SaveChanges();
                DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "delete from EnquirySkillDetails where EnquiryID =" + id + "; delete from EnquiryJobDetails where EnquiryID =" + id + "; delete from EnquiryFunctionTypeDetails where EnquiryID =" + id + "; delete from EnquiryDeviceDetails where EnquiryID =" + id, new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        
        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Customer")]
        public ActionResult CreateCustomer(Customer customer)
        {
            try
            {
                customer.CreatedByDate = DateTime.Now;
                customer.CreatedByID = CurrentUser.UserID;
                customer = _uow.Repository<Customer>().Insert(customer);
                _uow.SaveChanges();
                var _customers = _uow.Repository<Customer>().Get(x=>x.IsDeleted == false);
                return Json(new { status = "success", data = new { customers = _customers, customerid = customer.CustomerID } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "EnquiryStatus")]
        public ActionResult CreateEnquiryStatus(EnquiryStatus enquiryStatus)
        {
            try
            {
                enquiryStatus.CreatedByDate = DateTime.Now;
                enquiryStatus.CreatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryStatus>().Insert(enquiryStatus);
                _uow.SaveChanges();
                var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false).ToList();
                return Json(new { status = "success", data = new { enquiryStatus = _enquiryStatus, enquirystatusid = enquiryStatus.EnquiryStatusID } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "EnquiryType")]
        public ActionResult CreateEnquiryType(EnquiryType enquiryType)
        {
            try
            {
                enquiryType.CreatedByDate = DateTime.Now;
                enquiryType.CreatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryType>().Insert(enquiryType);
                _uow.SaveChanges();
                var _enquiryType = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false).ToList();
                return Json(new { status = "success", data = new { enquiryType = _enquiryType, enquirytypeid = enquiryType.EnquiryTypeID } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Device")]
        public ActionResult CreateEnquiryDevice(Device device)
        {
            try
            {
                device.CreatedByDate = DateTime.Now;
                device.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Device>().Insert(device);
                _uow.SaveChanges();
                var _device = _uow.Repository<Device>().Get(x => x.IsDeleted == false).ToList();
                return Json(new { status = "success", data = new { device = _device, deviceid = device.DeviceID } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Skill")]
        public ActionResult CreateEnquirySkill(Skill skill)
        {
            try
            {
                skill.CreatedByDate = DateTime.Now;
                skill.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Skill>().Insert(skill);
                _uow.SaveChanges();
                var _skill = _uow.Repository<Skill>().Get(x => x.IsDeleted == false).ToList();
                return Json(new { status = "success", data = new { skill = _skill, skillid = skill.SkillID } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EnquiryDeviceDelete(int id)
        {
            try
            {
                var _projectDevice = _uow.Repository<EnquiryDeviceDetail>().Get(x => x.EnquiryDeviceDetailID == id && x.IsDeleted == false).FirstOrDefault();
                _uow.Repository<EnquiryDeviceDetail>().Delete(id);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        public ActionResult EnquiryEmployeeDelete(int id)
        {
            try
            {
               // var _projectDevice = _uow.Repository<EnquiryEmpDetail>().Get(x => x.EnquiryEmpDetailID == id && x.IsDeleted == false).FirstOrDefault();
                _uow.Repository<EnquiryEmpDetail>().Delete(id);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }


        #endregion

        #region Enquiry Type
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "EnquiryType")]
        public ActionResult AllEnquiryTypes()
        {
            var _enquiryTypes = _uow.Repository<EnquiryType>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.EnquiryTypeID).ToList();
            return View(_enquiryTypes);
            //return View(new List<EnquiryType>() { new EnquiryType { } });
        }

        // GET: Employee/Details/5
        public ActionResult EnquiryTypeDetails(int id)
        {
            var _enquiry = _uow.Repository<EnquiryType>().Get(x => x.IsDeleted == false && x.EnquiryTypeID == id).ToList();
            return View(_enquiry);
        }

        // GET: Employee/Create
        public ActionResult EnquiryTypeCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "EnquiryType")]
        public ActionResult EnquiryTypeCreate(EnquiryType enquiryType)
        {
            try
            {
                enquiryType.CreatedByDate = DateTime.Now;
                enquiryType.CreatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryType>().Insert(enquiryType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult EnquiryTypeEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "EnquiryType")]
        public ActionResult EnquiryTypeEdit(EnquiryType enquiryType)
        {
            try
            {
                var _enquiryType = _uow.Repository<EnquiryType>().Get(x => x.EnquiryTypeID == enquiryType.EnquiryTypeID && x.IsDeleted == false).FirstOrDefault();
                _enquiryType.EnquiryTypeName = enquiryType.EnquiryTypeName;
                _enquiryType.Remarks = enquiryType.Remarks;
                _enquiryType.updatedByDate = DateTime.Now;
                _enquiryType.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryType>().Update(_enquiryType);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "EnquiryType")]
        public ActionResult EnquiryTypeDelete(int id)
        {
            try
            {
                var _enquiryType = _uow.Repository<EnquiryType>().Get(x => x.EnquiryTypeID == id && x.IsDeleted == false).FirstOrDefault();
                _enquiryType.updatedByDate = DateTime.Now;
                _enquiryType.UpdatedByID = CurrentUser.UserID;
                _enquiryType.IsDeleted = true;
                _uow.Repository<EnquiryType>().Update(_enquiryType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }


        #endregion


        #region Enquiry Status
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "EnquiryStatus")]
        public ActionResult AllEnquiryStatus()
        {
            var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.EnquiryStatusID).ToList();
            return View(_enquiryStatus);
            //return View(new List<EnquiryStatus>() { new EnquiryStatus { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "EnquiryStatus")]
        public ActionResult EnquiryStatusDetails(int id)
        {
            var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false && x.EnquiryStatusID == id).ToList();
            return View(_enquiryStatus);
        }

        // GET: Employee/Create
        public ActionResult EnquiryStatusCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "EnquiryStatus")]
        public ActionResult EnquiryStatusCreate(EnquiryStatus enquiryStatus)
        {
            try
            {
                enquiryStatus.CreatedByDate = DateTime.Now;
                enquiryStatus.CreatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryStatus>().Insert(enquiryStatus);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "EnquiryStatus")]
        public ActionResult EnquiryStatusEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "EnquiryStatus")]
        public ActionResult EnquiryStatusEdit(EnquiryStatus enquiryStatus)
        {
            try
            {
                var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false && x.EnquiryStatusID == enquiryStatus.EnquiryStatusID).FirstOrDefault();
                _enquiryStatus.EnquiryStatusName = enquiryStatus.EnquiryStatusName;
                _enquiryStatus.Remarks = enquiryStatus.Remarks;
                _enquiryStatus.updatedByDate = DateTime.Now;
                _enquiryStatus.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<EnquiryStatus>().Update(_enquiryStatus);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "EnquiryStatus")]
        public ActionResult EnquiryStatusDelete(int id)
        {
            try
            {
                var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false && x.EnquiryStatusID == id).FirstOrDefault();
                _enquiryStatus.updatedByDate = DateTime.Now;
                _enquiryStatus.UpdatedByID = CurrentUser.UserID;
                _enquiryStatus.IsDeleted = true;
                _uow.Repository<EnquiryStatus>().Update(_enquiryStatus);
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
