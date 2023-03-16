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
    public class DeviceController : Controller
    {
        private UnitOfWork _uow;
        public DeviceController(UnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Device")]
        public ActionResult AllDevices()
        {
            var _devices = _uow.Repository<Device>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.DeviceID).ToList();
            return View(_devices);
            //return View(new List<Device>() { new Device { } });
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Device")]
        public ActionResult Details(int id)
        {
            var _device = _uow.Repository<Device>().Get(x => x.IsDeleted == false && x.DeviceID == id).ToList();
            return View(_device);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Device")]
        public ActionResult Create(Device device)
        {
            try
            {
                device.CreatedByDate = DateTime.Now;
                device.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Device>().Insert(device);
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
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Device")]
        public ActionResult Edit(Device device)
        {
            try
            {
                var _device = _uow.Repository<Device>().Get(x => x.DeviceID == device.DeviceID && x.IsDeleted == false).FirstOrDefault();
                _device.DeviceName = device.DeviceName;
                _device.Audio = device.Audio;
                _device.Display = device.Display;
                _device.Media = device.Media;
                _device.Power = device.Power;
                _device.Recorder = device.Recorder;
                _device.Video = device.Video;
                _device.Remarks = device.Remarks;
                _device.Quantity = device.Quantity;
                _device.updatedByDate = DateTime.Now;
                _device.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Device>().Update(_device);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }

        // GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Employee/Delete/5
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Device")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _device = _uow.Repository<Device>().Get(x => x.DeviceID == id && x.IsDeleted == false).FirstOrDefault();
                _device.IsDeleted = true;
                _device.updatedByDate = DateTime.Now;
                _device.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Device>().Update(_device);
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