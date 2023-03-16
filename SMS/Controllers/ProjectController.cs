using SMS.Common;
using SMS.DataContext.Entities;
using SMS.DBAccess;
using SMS.Filter;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        private UnitOfWork _uow;
        public ProjectController(UnitOfWork uow)
        {
            _uow = uow;
        }

        #region Project

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Project")]
        public ActionResult AllProjects()
        {
            var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false);
            var _projects = _uow.Repository<Project>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.ProjectDate).ToList();
            var _devices = _uow.Repository<Device>().Get(x => x.IsDeleted == false);
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false);
            //var _jobs = _uow.Repository<Job>().Get(x => x.IsDeleted == false);
            var _functionTypes = _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false);
            var _enquiryStatus = _uow.Repository<EnquiryStatus>().Get(x => x.IsDeleted == false);
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false);
            var _projectEnquiryIDs = _projects.Select(x => x.EnquiryID);
            //var _enquiryCancelledStatusID = 0;
            //var _enquiryCancelledStatus =_enquiryStatus.FirstOrDefault(x => x.EnquiryStatusName.ToLower().Contains("cancel"));
            //if(_enquiryCancelledStatus != null)
            //{
            //    _enquiryCancelledStatusID = _enquiryCancelledStatus.EnquiryStatusID;
            //}
            var _enquiryConfirmedStatusID = 0;
            var _enquiryConfirmedStatus = _enquiryStatus.FirstOrDefault(x => x.EnquiryStatusName.ToLower().Contains("confirm"));
            if (_enquiryConfirmedStatus != null)
            {
                _enquiryConfirmedStatusID = _enquiryConfirmedStatus.EnquiryStatusID;
            }
            //var _enquiryCancelledStatusID = "EnquiryStatusCancelled".GetConfigByKey<int>();
            var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false && 
            x.EnquiryStatusID == _enquiryConfirmedStatusID && !_projectEnquiryIDs.Contains(x.EnquiryID)).OrderByDescending(x=>x.EnquiryDate).ToList();
            var _project = _projects.OrderByDescending(x => x.ProjectID).FirstOrDefault();
            var _employeeSkillDetails = _uow.Repository<EmployeeSkillDetail>().Get(x => x.IsDeleted == false)
                .Select(x => new EmployeeSkillDetail { EmployeeID = x.EmployeeID, SkillID = x.SkillID, EmployeeSkillDetailID = x.EmployeeSkillDetailID }).ToList();

            var _projectID = 0;
            if (_project != null)
            {
                _projectID = _project.ProjectID + 1;
            }
            return View(new ProjectComplexModel { EmployeeSkills = _employeeSkillDetails, Employees = _employees, Devices = _devices,
                Enquiries = _enquiries, Projects = _projects, ProjectStatus = _projectStatus,
                FunctionTypes = _functionTypes, Skills = _skills,
                Project = new Project { ProjectID = _projectID, ProjectTime = DateTime.Now.TimeOfDay,
                    ProjectStartDate = DateTime.Now, ProjectEndDate = DateTime.Now, ProjectDate = DateTime.Now,
                    Payment1 = 0, Payment2 = 0, Payment3 = 0, Payment4 = 0,Balance=0} });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Project")]
        public ActionResult Details(int id)
        {
            //var _project = _uow.Repository<Project>().Get(x => x.IsDeleted == false && x.ProjectID == id).FirstOrDefault();
            var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false);
            var _projects = _uow.Repository<Project>().Get(x => x.IsDeleted == false).OrderByDescending(x=>x.ProjectDate).ToList();
            var _project = _projects.FirstOrDefault(x => x.ProjectID == id);
            //var _projectStatusCompleted = "ProjectStatusCompleted".GetConfigByKey<int>();
            //var _ongoingProjectIDs = _projects.Where(x=>x.ProjectStatusID != _projectStatusCompleted)
            //    .Select(x=>x.ProjectID);
            var _projectEnquiryIDs = _projects.Select(x => x.EnquiryID);
            var _enquiryCancelledStatusID = "EnquiryStatusCancelled".GetConfigByKey<int>();
            var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false &&
            x.EnquiryStatusID != _enquiryCancelledStatusID && !_projectEnquiryIDs.Contains(x.EnquiryID)).ToList();
            //var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false).ToList();
            //var _projectDevices = _uow.Repository<ProjectDeviceDetail>().Get();
            //var _ongoingProjectDevices = _projectDevices.Where(x => _ongoingProjectIDs.Contains(x.ProjectID)).ToList();
            var _projectDevices = _uow.Repository<ProjectDeviceDetail>().Get(x => x.ProjectID == _project.ProjectID)
                .Select(x => new ProjectDeviceDetail { ProjectDeviceDetailID = x.ProjectDeviceDetailID, ProjectID = x.ProjectID, DeviceID = x.DeviceID, Quantity = x.Quantity, FromDate = x.FromDate, ToDate = x.ToDate , IsHired = x.IsHired, HiredCost = x.HiredCost }).ToList();
            //var _projectFunctionTypes = _uow.Repository<ProjectFunctionTypeDetail>().Get(x => x.IsDeleted == false && x.ProjectID == _project.ProjectID).Select(x => new ProjectFunctionTypeDetail { ProjectID = x.ProjectID, FunctionTypeID = x.FunctionTypeID }).ToList();
            //var _projectJobs = _uow.Repository<ProjectJobDetail>().Get(x => x.IsDeleted == false && x.ProjectID == _project.ProjectID)
                //.Select(x => new ProjectJobDetail { ProjectJobDetailID = x.ProjectJobDetailID, ProjectID = x.ProjectID, JobID = x.JobID, FromDate = x.FromDate, ToDate = x.ToDate }).ToList();
            var _projectEmployees = _uow.Repository<ProjectEmpDetail>().Get(x => x.IsDeleted == false && x.ProjectID == _project.ProjectID)
                .Select(x => new ProjectEmpDetail { ProjectID = x.ProjectID,EmployeeName=x.EmployeeName,CompanyName=x.CompanyName, EmployeeID = x.EmployeeID, FromDate = x.FromDate, ToDate = x.ToDate,SkillID=x.SkillID , ProjectEmpDetailID = x.ProjectEmpDetailID, HiredCost=x.HiredCost,IsHired=x.IsHired }).ToList();
            //var _projectSkills = _uow.Repository<ProjectSkillDetail>().Get(x => x.IsDeleted == false && x.ProjectID == _project.ProjectID).Select(x => new ProjectSkillDetail { ProjectID = x.ProjectID, SkillID = x.SkillID }).ToList();
            var _projectStatusDetails = _uow.Repository<ProjectStatusDetail>().Get(x => x.IsDeleted == false && x.ProjectID == _project.ProjectID)
                .Select(x => new ProjectStatusDetail { ProjectID = x.ProjectID, CreatedByDate = x.CreatedByDate, ProjectStatusID = x.ProjectStatusID }).ToList();
            var _devices = _uow.Repository<Device>().Get(x => x.IsDeleted == false);
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false);
            //var _jobs = _uow.Repository<Job>().Get(x => x.IsDeleted == false);
            var _functionTypes = _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false);
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false);
            var _employeeSkillDetails = _uow.Repository<EmployeeSkillDetail>().Get(x => x.IsDeleted == false)
                .Select(x => new EmployeeSkillDetail { EmployeeID = x.EmployeeID, SkillID = x.SkillID, EmployeeSkillDetailID = x.EmployeeSkillDetailID }).ToList();
            var _filesPath = new List<string>();
            string[] allFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Content/Documents/Project/"));//Change path to yours
            //foreach (string file in allFiles)
            for (int i = 0; i < allFiles.Length; i++)
            {
                //var _fileName = allFiles[i].Split('\\').LastOrDefault().ToLower();
                if (allFiles[i].Contains(_project.ProjectName + "-" + _project.ProjectID) && !allFiles[i].Contains("Deleted"))
                {
                    _filesPath.Add(allFiles[i].Substring(allFiles[i].LastIndexOf('\\') + 1));
                }
            }
            _project.FilesPath =  Newtonsoft.Json.JsonConvert.SerializeObject(_filesPath);
            return View("AllProjects", new ProjectComplexModel {
                EmployeeSkills = _employeeSkillDetails,
                Employees = _employees,
                Devices = _devices,
                Enquiries = _enquiries,
                Project = _project,
                Projects = _projects,
                //OnGoingProjectDevices = _ongoingProjectDevices,
                ProjectStatus = _projectStatus,
                ProjectStatusDetails = _projectStatusDetails,
                FunctionTypes = _functionTypes,
                //Jobs = _jobs,
                Skills = _skills,
                ProjectDevices = _projectDevices,
                ProjectEmployees = _projectEmployees,
                //ProjectFunctionTypes = _projectFunctionTypes,
                //ProjectJobs = _projectJobs,
                //ProjectSkills = _projectSkills
            });

        }
        [HttpGet]
        public ActionResult EnquiryDetails(int id)
        {
            var _enquiry = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false && x.EnquiryID == id).FirstOrDefault();
            var _enquiryDevices = _uow.Repository<EnquiryDeviceDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID)
                .Select(x => new EnquiryDeviceDetail { EnquiryID = x.EnquiryID,Device=x.Device, DeviceID = x.DeviceID, HiredCost = x.HiredCost, FromDate = x.FromDate, IsHired = x.IsHired, Quantity = x.Quantity, ToDate = x.ToDate, EnquiryDeviceDetailID = x.EnquiryDeviceDetailID }).ToList();
            var _enquiryEmployees = _uow.Repository<EnquiryEmpDetail>().Get(x => x.IsDeleted == false && x.EnquiryID == _enquiry.EnquiryID)
                .Select(x => new EnquiryEmpDetail { EnquiryID = x.EnquiryID,EmployeeName=x.EmployeeName,CompanyName=x.CompanyName, EmployeeID = x.EmployeeID,Skill=x.Skill, SkillID = x.SkillID, EnquiryEmpDetailID = x.EnquiryEmpDetailID, HiredCost = x.HiredCost, IsHired = x.IsHired, FromDate = x.FromDate, ToDate = x.ToDate }).ToList();
            return Json(new
            {
                status = "success",
                data = new
                {
                    EnquiryDevices = _enquiryDevices,
                    EnquiryEmployees = _enquiryEmployees,
                    Enquiry = _enquiry
                }
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CheckDeviceAvailability(int DeviceID,int DeviceQuantity,int Quantity,int CurrentQuantity,DateTime FromDate,DateTime ToDate, DateTime ProjectStartDate, DateTime ProjectEndDate)
        {
            var _isDateAvailable = true;
            var _isQuantityAvailable = true;
            var _quantityAvailable = 0;
            var _avaiableDates = new List<string>();
            var _projectStatusCompleted = "ProjectStatusCompleted".GetConfigByKey<int>();
            var _ongoingProjectIDs = _uow.Repository<Project>().Get(x => x.ProjectStatusID != _projectStatusCompleted)
               .Select(x => x.ProjectID).ToList();
            var _projectDevices = _uow.Repository<ProjectDeviceDetail>().Get(x=>x.DeviceID == DeviceID && _ongoingProjectIDs.Contains(x.ProjectID));           
            if (_projectDevices != null)
            {
                var _previousQuantity = _projectDevices.Select(x => x.Quantity).Sum();
                if((Quantity + _previousQuantity) > DeviceQuantity)
                {
                    _isQuantityAvailable = false;
                    _quantityAvailable = DeviceQuantity - _previousQuantity - CurrentQuantity;
                }
                for (DateTime startDate = FromDate; startDate <= ToDate; startDate = startDate.AddDays(1))
                {
                    if(_projectDevices.Any(x=>x.FromDate <= startDate && x.ToDate >= startDate))
                    {
                        _isDateAvailable = false;
                    }
                }
                if(_isDateAvailable == false)
                {
                    for (DateTime startDate = ProjectStartDate; startDate <= ProjectEndDate; startDate = startDate.AddDays(1))
                    {
                        if (!_projectDevices.Any(x => x.FromDate <= startDate && x.ToDate >= startDate))
                        {
                            _avaiableDates.Add(startDate.ToString("dd/MM/yyyy"));
                        }
                    }
                }
                
            }
            return Json(new
            {
                status = "success",
                data = new
                {
                    quantityAvailable = _quantityAvailable,
                    isQuantityAvailable = _isQuantityAvailable,
                    avaiableDates = _avaiableDates,
                    isDateAvailable = _isDateAvailable
                }
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CheckEmployeeAvailability(int EmployeeID,DateTime FromDate, DateTime ToDate, DateTime ProjectStartDate, DateTime ProjectEndDate)
        {
            var _isDateAvailable = true;
            var _avaiableDates = new List<string>();
            var _projectStatusCompleted = "ProjectStatusCompleted".GetConfigByKey<int>();
            var _ongoingProjectIDs = _uow.Repository<Project>().Get(x => x.ProjectStatusID != _projectStatusCompleted)
               .Select(x => x.ProjectID).ToList();
            var _projectEmployees = _uow.Repository<ProjectEmpDetail>().Get(x => x.EmployeeID == EmployeeID && _ongoingProjectIDs.Contains(x.ProjectID));
            if (_projectEmployees != null)
            {
                for (DateTime startDate = FromDate; startDate <= ToDate; startDate = startDate.AddDays(1))
                {
                    if (_projectEmployees.Any(x => x.FromDate <= startDate && x.ToDate >= startDate))
                    {
                        _isDateAvailable = false;
                    }
                }
                if (_isDateAvailable == false)
                {
                    for (DateTime startDate = ProjectStartDate; startDate <= ProjectEndDate; startDate = startDate.AddDays(1))
                    {
                        if (!_projectEmployees.Any(x => x.FromDate <= startDate && x.ToDate >= startDate))
                        {
                            _avaiableDates.Add(startDate.ToString("dd/MM/yyyy"));
                        }
                    }
                }
            }
            return Json(new
            {
                status = "success",
                data = new
                {
                    avaiableDates = _avaiableDates,
                    isDateAvailable = _isDateAvailable
                }
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Project")]
        public ActionResult Create(Project project,string FileNames, string ProjectJobs, string ProjectDevices, string EmployeeSkills, string ProjectSkills, string ProjectEmployees)
        {
            try
            {
               
                project.CreatedByDate = DateTime.Now;
                project.CreatedByID = CurrentUser.UserID;
                project = _uow.Repository<Project>().Insert(project);
                _uow.SaveChanges();
                if (project.FilesPath != null)
                {
                    var _previousFilesCount = 0;
                    string[] allFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Content/Documents/Project/"));//Change path to yours
                    foreach (string file in allFiles)
                    {
                        if (file.Contains(project.ProjectName))
                        {
                            _previousFilesCount++;
                        }
                    }
                    var files = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(project.FilesPath);
                    var fileNames = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(FileNames);
                    for (int i = 0; i < files.Count; i++)
                    {
                        var _ext = Path.GetExtension(fileNames[i]);
                        Byte[] bytes = Convert.FromBase64String(files[i].Substring((files[i].IndexOf(',') + 1)));
                        System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Documents/Project/" + project.ProjectName + "-" + project.ProjectID + "-" + (_previousFilesCount + i + 1) + _ext), bytes);
                        //if (document.SearchName.IndexOf('.') > 0)
                        //    document.SearchName = document.SearchName.Substring(0, document.SearchName.LastIndexOf('.'));
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Documents/Project/" + project.ProjectName + "." + document.FileExt), bytes);
                    }
                }
                var _projectEmployees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectEmpDetail>>(EmployeeSkills);
                //var _projectJobs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectJobDetail>>(ProjectJobs);
                //var _projectSkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectSkillDetail>>(ProjectSkills);
                var _projectDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectDeviceDetail>>(ProjectDevices);
                //var _projectEmployees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectEmpDetail>>(ProjectEmployees);
                for (int i = 0; i < _projectDevices.Count; i++)
                {
                    _projectDevices[i].ProjectID = project.ProjectID;
                }
                
                for (int i = 0; i < _projectEmployees.Count; i++)
                {
                    _projectEmployees[i].ProjectID = project.ProjectID;
                }
                _uow.Repository<ProjectStatusDetail>().Insert(new ProjectStatusDetail { ProjectID = project.ProjectID, ProjectStatusID = project.ProjectStatusID, CreatedByDate = DateTime.Now });
                //_uow.Repository<ProjectSkillDetail>().InsertList(_projectSkills);
               // _uow.Repository<ProjectJobDetail>().InsertList(_projectJobs);
                _uow.Repository<ProjectDeviceDetail>().InsertList(_projectDevices);
                _uow.Repository<ProjectEmpDetail>().InsertList(_projectEmployees);
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
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Project")]
        public ActionResult Edit(Project project,string FileNames, string EmployeeSkills, string ProjectDevices, string ProjectFunctionTypes, string ProjectSkills, string ProjectEmployees)
        {
            try
            {
                var _project = _uow.Repository<Project>().Get(x => x.ProjectID == project.ProjectID && x.IsDeleted == false).FirstOrDefault();
                string[] allFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Content/Documents/Project/"));//Change path to yours
                if(project.ProjectName != _project.ProjectName)
                {
                    for (int i = 0; i < allFiles.Length; i++)
                    {
                        System.IO.File.Move(allFiles[i] ,allFiles[i].Replace(_project.ProjectName,project.ProjectName));
                    }
                }
                if (project.FilesPath != null)
                {
                    var _previousFilesCount = 0;
                    
                    foreach (string file in allFiles)
                    {
                        if (file.Contains(project.ProjectName) && !file.Contains("Deleted"))
                        {
                            _previousFilesCount++;
                        }
                    }
                    var files = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(project.FilesPath);
                    var fileNames = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(FileNames);
                    for (int i = 0; i < files.Count; i++)
                    {
                        var _ext = Path.GetExtension(fileNames[i]);
                        Byte[] bytes = Convert.FromBase64String(files[i].Substring((files[i].IndexOf(',') + 1)));
                        System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Documents/Project/" + project.ProjectName + "-" + project.ProjectID + "-" + (_previousFilesCount + i + 1) + _ext), bytes);
                        //if (document.SearchName.IndexOf('.') > 0)
                        //    document.SearchName = document.SearchName.Substring(0, document.SearchName.LastIndexOf('.'));
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Documents/Project/" + project.ProjectName + "." + document.FileExt), bytes);
                    }
                }
                _project.updatedByDate = DateTime.Now;
                _project.UpdatedByID = CurrentUser.UserID;
                _project.ChargeableAmount = project.ChargeableAmount;
                _project.ProjectDate = project.ProjectDate;
                _project.ProjectStatusID = project.ProjectStatusID;
                _project.ProjectTime = project.ProjectTime;
                _project.ProjectName = project.ProjectName;
                _project.ProjectStartDate = project.ProjectStartDate;
                _project.ProjectEndDate = project.ProjectEndDate;
                _project.Payment1 = project.Payment1;
                _project.Payment2 = project.Payment2;
                _project.Payment3 = project.Payment3;
                _project.Payment4 = project.Payment4;
                _project.PaymentDate1 = project.PaymentDate1;
                _project.PaymentDate2 = project.PaymentDate2;
                _project.PaymentDate3 = project.PaymentDate3;
                _project.PaymentDate4 = project.PaymentDate4;
                _project.FunctionTypeID = project.FunctionTypeID;
                _project.Vat = project.Vat;
                _project.ContractName = project.ContractName;
                _project.ContractNumber = project.ContractNumber;
                _project.Balance = project.Balance;
                _project.MaxCost = project.MaxCost;
                _project.ActualCost = project.ActualCost;
                _project.HoursRequired = project.HoursRequired;
                _project.Discount = project.Discount;
                _project.Venue = project.Venue;
                _project.ParticipantOne = project.ParticipantOne;
                _project.ParticipantTwo = project.ParticipantTwo;
                //_project.NoOfUnits = project.NoOfUnits;
                _project.TotalCost = project.TotalCost;
                _project.EnquiryID = project.EnquiryID;
                _project.Remarks = project.Remarks;
                _uow.Repository<Project>().Update(_project);
                DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "delete from ProjectEmpDetails where ProjectID =" + project.ProjectID + "; delete from ProjectSkillDetails where ProjectID =" + project.ProjectID + "; delete from ProjectJobDetails where ProjectID =" + project.ProjectID + "; delete from ProjectFunctionTypeDetails where ProjectID =" + project.ProjectID + "; delete from ProjectDeviceDetails where ProjectID =" + project.ProjectID, new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
               // var _projectFunctionTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectFunctionTypeDetail>>(ProjectFunctionTypes);
                //var _projectJobs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectJobDetail>>(ProjectJobs);
                //var _projectSkills = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectSkillDetail>>(ProjectSkills);
                var _projectDevices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectDeviceDetail>>(ProjectDevices);
                var _projectEmployees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectEmpDetail>>(EmployeeSkills);
                if(_project.ProjectStatusID != project.ProjectStatusID)
                {
                    _uow.Repository<ProjectStatusDetail>().Insert(new ProjectStatusDetail { ProjectID = project.ProjectID, ProjectStatusID = project.ProjectStatusID, CreatedByDate = project.CreatedByDate });
                }
                for (int i = 0; i < _projectDevices.Count; i++)
                {
                    _projectDevices[i].ProjectID = _project.ProjectID;
                }
                for (int i = 0; i < _projectEmployees.Count; i++)
                {
                    _projectEmployees[i].ProjectID = _project.ProjectID;
                }
                //_uow.Repository<ProjectSkillDetail>().InsertList(_projectSkills);
                //_uow.Repository<ProjectJobDetail>().InsertList(_projectJobs);
                _uow.Repository<ProjectDeviceDetail>().InsertList(_projectDevices);
                //_uow.Repository<ProjectFunctionTypeDetail>().InsertList(_projectFunctionTypes);
                _uow.Repository<ProjectEmpDetail>().InsertList(_projectEmployees);
                _uow.SaveChanges();
                return Json(new { status = "success", returnUrl = "../Project/AllProjects" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Project")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _project = _uow.Repository<Project>().Get(x => x.ProjectID == id && x.IsDeleted == false).FirstOrDefault();
                _project.updatedByDate = DateTime.Now;
                _project.UpdatedByID = CurrentUser.UserID;
                _project.IsDeleted = true;
                _uow.Repository<Project>().Update(_project);
                _uow.SaveChanges();
                DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS, "delete from ProjectEmpDetails where ProjectID =" + id + "; delete from ProjectSkillDetails where ProjectID =" + id + "; delete from ProjectJobDetails where ProjectID =" + id + "; delete from ProjectFunctionTypeDetails where ProjectID =" + id + "; delete from ProjectDeviceDetails where ProjectID =" + id, new Dictionary<string, System.Data.SqlClient.SqlParameter> { });
                string[] allFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Content/Documents/Project/"));//Change path to yours             
                for (int i = 0; i < allFiles.Length; i++)
                {
                    System.IO.File.Move(allFiles[i], allFiles[i].Replace(_project.ProjectName, _project.ProjectName + "-Deleted"));
                }
                return Json(new { status = "success" , data= "true" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult ProjectJobDelete(int id)
        {
                try
                {
                    //var _projectJob = _uow.Repository<ProjectJobDetail>().Get(x => x.ProjectJobDetailID == id && x.IsDeleted == false).FirstOrDefault();
                    _uow.Repository<ProjectJobDetail>().Delete(id);
                    _uow.SaveChanges();
                    return Json(new { status = "success" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", error = ex.Message });
                }
        }
        [HttpPost]
        public ActionResult ProjectEmployeeDelete(int id)
        {
            try
            {
                _uow.Repository<ProjectEmpDetail>().Delete(id);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult ProjectDeviceDelete(int id)
        {
            try
            {
                var _projectDevice = _uow.Repository<ProjectDeviceDetail>().Get(x => x.ProjectDeviceDetailID == id && x.IsDeleted == false).FirstOrDefault();
                _uow.Repository<ProjectDeviceDetail>().Delete(id);
                _uow.SaveChanges();
                return Json(new { status = "success"});
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }


        #endregion

        #region Project Status

        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "ProjectStatus")]
        public ActionResult AllProjectStatus()
        {
            var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.ProjectStatusID).ToList();
            return View(_projectStatus);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        public ActionResult ProjectStatusDetails(int id)
        {
            var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false && x.ProjectStatusID == id).FirstOrDefault();
            return View(_projectStatus);
        }

        // GET: Employee/Create
        public ActionResult ProjectStatusCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "ProjectStatus")]
        public ActionResult ProjectStatusCreate(ProjectStatus projectStatus)
        {
            try
            {
                projectStatus.CreatedByDate = DateTime.Now;
                projectStatus.CreatedByID = CurrentUser.UserID;
                _uow.Repository<ProjectStatus>().Insert(projectStatus);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        public ActionResult ProjectStatusEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "ProjectStatus")]
        public ActionResult ProjectStatusEdit(ProjectStatus projectStatus)
        {
            try
            {
                var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false && x.ProjectStatusID == projectStatus.ProjectStatusID).FirstOrDefault();
                _projectStatus.ProjectStatusName = projectStatus.ProjectStatusName;
                _projectStatus.Remarks = projectStatus.Remarks;
                _projectStatus.updatedByDate = DateTime.Now;
                _projectStatus.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<ProjectStatus>().Update(_projectStatus);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "ProjectStatus")]
        public ActionResult ProjectStatusDelete(int id)
        {
            try
            {
                var _projectStatus = _uow.Repository<ProjectStatus>().Get(x => x.IsDeleted == false && x.ProjectStatusID == id).FirstOrDefault();
                _projectStatus.updatedByDate = DateTime.Now;
                _projectStatus.UpdatedByID = CurrentUser.UserID;
                _projectStatus.IsDeleted = true;
                _uow.Repository<ProjectStatus>().Update(_projectStatus);
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
