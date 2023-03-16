//using AutoMapper;
using SMS.Common;
using SMS.DataContext.Entities;
using SMS.DBAccess;
using SMS.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class FunctionController : Controller
    {
        // GET: Equiry
        private UnitOfWork _uow;
        public FunctionController(UnitOfWork uow)
        {
            _uow = uow;
        }
        public FunctionController()
        {
        }


        #region Function Type
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "FunctionType")]
        public ActionResult AllFunctionTypes()
        {
            var _functionTypes = //Mapper.Map<IList<FunctionType>, List<UserModel>>
                _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.FunctionTypeID).ToList();
            return View(_functionTypes);
            //return View(new List<FunctionType>() { new FunctionType { } });
        }

        // GET: Employee/Details/5
        public ActionResult FunctionTypeDetails(int id)
        {
            var _enquiry = _uow.Repository<FunctionType>().Get(x => x.IsDeleted == false && x.FunctionTypeID == id).ToList();
            return View(_enquiry);
        }

        // GET: Employee/Create
        public ActionResult FunctionTypeCreate()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "FunctionType")]
        public ActionResult FunctionTypeCreate(FunctionType functionType)
        {
            try
            {
                functionType.CreatedByDate = DateTime.Now;
                functionType.CreatedByID = CurrentUser.UserID;
                _uow.Repository<FunctionType>().Insert(functionType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "FunctionType")]
        public ActionResult FunctionTypeEdit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "FunctionType")]
        public ActionResult FunctionTypeEdit(FunctionType functionType)
        {
            try
            {
                var _functionType = _uow.Repository<FunctionType>().Get(x => x.FunctionTypeID == functionType.FunctionTypeID && x.IsDeleted == false).FirstOrDefault();
                _functionType.FunctionTypeName = functionType.FunctionTypeName;
                _functionType.Remarks = functionType.Remarks;
                _functionType.updatedByDate = DateTime.Now;
                _functionType.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<FunctionType>().Update(_functionType);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "FunctionType")]
        public ActionResult FunctionTypeDelete(int id)
        {
            try
            {
                var _functionType = _uow.Repository<FunctionType>().Get(x => x.FunctionTypeID == id && x.IsDeleted == false).FirstOrDefault();
                _functionType.IsDeleted = true;
                _functionType.updatedByDate = DateTime.Now;
                _functionType.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<FunctionType>().Update(_functionType);
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
