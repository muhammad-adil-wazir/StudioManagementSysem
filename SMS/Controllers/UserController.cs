//using AutoMapper;
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
    public class UserController : Controller
    {
        private UnitOfWork _uow;
        public UserController(UnitOfWork uow)
        {
            _uow = uow;
        }

        #region User
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "User")]
        public ActionResult AllUsers()
        {
            //var _users = Mapper.Map<IList<User>, List<UserModel>>(_uow.Repository<User>().Get(x => x.IsDeleted == false));
            //var _roles = Mapper.Map<IList<Role>, List<RoleModel>>(_uow.Repository<Role>().Get(x => x.IsDeleted == false));
            //var _employees = Mapper.Map<IList<Employee>, List<EmployeeModel>>(_uow.Repository<Employee>().Get(x => x.IsDeleted == false));
            var _users = _uow.Repository<User>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.UserID).ToList();
            var _roles = _uow.Repository<Role>().Get(x => x.IsDeleted == false);
            var _employees = _uow.Repository<Employee>().Get(x => x.IsDeleted == false);
            return View(new UserComplexModel { Employees = _employees, Roles = _roles, User = _users });
            //return View(new List<User>() { new User { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "User")]
        public ActionResult Details(int id)
        {
            var _user = _uow.Repository<User>().Get(x => x.IsDeleted == false && x.UserID == id).ToList();
            return View(_user);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "User")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "User")]
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                user.CreatedByDate = DateTime.Now;
                user.CreatedByID = CurrentUser.UserID;
                user.Password = Utilities.Encrypt(user.Password);
                _uow.Repository<User>().Insert(user);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "User")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "User")]
        public ActionResult Edit(User user)
        {
            try
            {
                var _user = _uow.Repository<User>().Get(x => x.UserID == user.UserID && x.IsDeleted == false).FirstOrDefault();
                _user.UserName = user.UserName;
                _user.EmployeeID = user.EmployeeID;
                //_user.Password = user.Password;
                _user.RoleID = user.RoleID;
                _user.UserName = user.UserName;
                _user.Remarks = user.Remarks;
                _user.updatedByDate = DateTime.Now;
                _user.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<User>().Update(_user);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // POST: Employee/Delete/5
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "User")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var _user = _uow.Repository<User>().Get(x => x.UserID == id && x.IsDeleted == false).FirstOrDefault();
                _user.updatedByDate = DateTime.Now;
                _user.UpdatedByID = CurrentUser.UserID;
                _user.IsDeleted = true;
                _uow.Repository<User>().Update(_user);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Interface
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Interface")]
        public ActionResult AllInterfaces()
        {
            var _interfaces = _uow.Repository<Interface>().Get(x => x.IsDeleted == false).ToList();
            return View(_interfaces);
        }
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Interface")]
        // GET: Employee/Details/5
        public ActionResult InterfaceDetails(int id)
        {
            var _interface = _uow.Repository<Interface>().Get(x => x.IsDeleted == false && x.InterfaceID == id).ToList();
            return View(_interface);
        }
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Interface")]
        // GET: Employee/Create
        public ActionResult InterfaceCreate()
        {

            return View();
        }
        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Interface")]
        public ActionResult InterfaceCreate(Interface interfacee)
        {
            try
            {
                if(interfacee.ParentInterfaceID == 0)
                {
                    interfacee.ParentInterfaceID = null;
                }
                interfacee.CreatedByDate = DateTime.Now;
                interfacee.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Interface>().Insert(interfacee);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Interface")]
        public ActionResult InterfaceEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Interface")]
        public ActionResult InterfaceEdit(Interface interfacee)
        {
            try
            {
                var _interface = _uow.Repository<Interface>().Get(x => x.InterfaceID == interfacee.InterfaceID  && x.IsDeleted == false).FirstOrDefault();
                _interface.InterfaceName = interfacee.InterfaceName;
                _interface.ParentInterfaceID = interfacee.ParentInterfaceID;
                _interface.Remarks = interfacee.Remarks;
                _interface.updatedByDate = DateTime.Now;
                _interface.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Interface>().Update(_interface);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Interface")]
        public ActionResult InterfaceDelete(int id)
        {
            try
            {
                var _interface = _uow.Repository<Interface>().Get(x => x.InterfaceID == id && x.IsDeleted == false).FirstOrDefault();
                _interface.IsDeleted = true;
                _interface.updatedByDate = DateTime.Now;
                _interface.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Interface>().Update(_interface);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region Role
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Role")]
        public ActionResult AllRoles()
        {
            var aaa = Response.StatusCode;
            var _roles = _uow.Repository<Role>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.RoleID).ToList();
            return View(_roles);
            //return View(new List<Job>() { new Job { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Role")]
        public ActionResult RoleDetails(int id)
        {
            var _role = _uow.Repository<Role>().Get(x => x.IsDeleted == false && x.RoleID == id).ToList();
            return View(_role);
        }

        // GET: Employee/Create
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Role")]
        public ActionResult RoleCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Role")]
        public ActionResult RoleCreate(Role role)
        {
            try
            {
                role.CreatedByDate = DateTime.Now;
                role.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Role>().Insert(role);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Role")]
        public ActionResult RoleEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Role")]
        [HttpPost]
        public ActionResult RoleEdit(Role role)
        {
            try
            {
                var _role = _uow.Repository<Role>().Get(x => x.RoleID == role.RoleID && x.IsDeleted == false).FirstOrDefault();
                _role.RoleName = role.RoleName;
                _role.Remarks = role.Remarks;
                _role.updatedByDate = DateTime.Now;
                _role.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Role>().Update(_role);
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
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Role")]
        public ActionResult RoleDelete(int id)
        {
            try
            {
                var _role = _uow.Repository<Role>().Get(x => x.RoleID == id && x.IsDeleted == false).FirstOrDefault();
                _role.IsDeleted = true;
                _role.updatedByDate = DateTime.Now;
                _role.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Role>().Update(_role);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        #endregion

        #region User Access 

        //  [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "RoleAccess")]
        public ActionResult AllUserAccessByRoleId(int Id)
        {
            var _roleAccessDetail = _uow.Repository<RoleAccess>().Get(a => a.IsDeleted == false && a.RoleID == Id).ToList();
            //List<UserAccessDetailModel> _userAccessDetailModel = Mapper.Map<List<UserAccessDetail>, List<UserAccessDetailModel>>(_userAccessDetail);
            return Json(_roleAccessDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AllEventAccess()
        {
            var _eventAccess = _uow.Repository<EventAccess>().Get();
            return Json(_eventAccess, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "RoleAccess")]
        public ActionResult RoleAccess(int RoleID = 0)
        {
            
            var _interfaces = _uow.Repository<Interface>().Get(x => x.IsDeleted == false);
            var _roles = _uow.Repository<Role>().Get(x => x.IsDeleted == false);
            var _eventAccess = _uow.Repository<EventAccess>().Get(x => x.IsDeleted == false);
            if (RoleID == 0)
            {
                RoleID = _roles.ToArray()[0].RoleID;
            }
            var _roleAccess = _uow.Repository<RoleAccess>().Get(x => x.IsDeleted == false && x.RoleID == RoleID);
            return View(new RoleAccessComplexModel { EventAccess = _eventAccess, Roles = _roles, Interfaces = _interfaces , RoleAccess = _roleAccess });
            //return View();
        }
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "RoleAccess")]
        public ActionResult RoleAccessCreate(List<RoleAccess> roleAccessDetail)
        {
            //List<RoleAccess> _userAccessDetail = Mapper.Map<List<UserAccessDetailModel>, List<UserAccessDetail>>(userAccessDetailModel);
            for (int i = 0; i < roleAccessDetail.Count; i++)
            {
                roleAccessDetail[i].CreatedByID = CurrentUser.UserID;
                roleAccessDetail[i].CreatedByDate = DateTime.Now;
            }
            //_userAccessDetailService.ExecSql("UserAccess_DeleteByRoleID"
            //, new SqlParameter("@UserRoleID", SqlDbType.Int) { Value = userAccessDetailModel[0].UserRoleID}
            //);
            DataBaseAccess.ExecuteQuery(DataBaseAccess.DBSMS,"delete from RoleAccesses where roleid =" + roleAccessDetail[0].RoleID, new Dictionary<string, System.Data.SqlClient.SqlParameter> { } );
            //_userAccessDetailService.ExecSqlQuery("delete from useraccessdetails where userroleid =" + userAccessDetailModel[0].UserRoleID);
            //_userAccessDetailService.DeleteBulk(_userAccessDetail);
            _uow.Repository<RoleAccess>().InsertList(roleAccessDetail);
            _uow.SaveChanges();
            //_userAccessDetailService.AddRange(_userAccessDetail);
            //Utilities.UserAccess = _userAccessDetail;
            return Json(new { status = "success" });
        }

        #endregion
    }
}