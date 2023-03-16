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
    public class JobController : Controller
    {
        private UnitOfWork _uow;
        public JobController(UnitOfWork uow)
        {
            _uow = uow;
        }
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Job")]
        public ActionResult AllJobs()
        {
            var _jobs = _uow.Repository<Job>().Get(x => x.IsDeleted == false).ToList();
            return View(_jobs);
        }

        // GET: Employee/Details/5
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Job")]
        public ActionResult Details(int id)
        {
            var _job = _uow.Repository<Job>().Get(x => x.IsDeleted == false && x.JobID == id).ToList();
            return View(_job);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Job")]
        public ActionResult Create(Job job)
        {
            try
            {
                job.CreatedByDate = DateTime.Now;
                job.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Job>().Insert(job);
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
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Job")]
        public ActionResult Edit(Job job)
        {
            try
            {
                var _job = _uow.Repository<Job>().Get(x => x.IsDeleted == false && x.JobID == job.JobID).FirstOrDefault();
                _job.JobName = job.JobName;
                _job.Remarks = job.Remarks;
                _job.updatedByDate = DateTime.Now;
                _job.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Job>().Update(_job);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Job")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _job = _uow.Repository<Job>().Get(x => x.IsDeleted == false && x.JobID == id).FirstOrDefault();
                _job.updatedByDate = DateTime.Now;
                _job.UpdatedByID = CurrentUser.UserID;
                _job.IsDeleted = true;
                _uow.Repository<Job>().Update(_job);
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