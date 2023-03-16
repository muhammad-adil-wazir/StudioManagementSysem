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
    //[Authorize]
    public class SkillController : Controller
    {
        private UnitOfWork _uow;
        public SkillController(UnitOfWork uow)
        {
            _uow = uow;
        }
        public SkillController()
        {
        }
        // GET: Employee
        [AccessAuthenticationFilter(EventAccess = "View", InterfaceName = "Skill")]
        public ActionResult AllSkills()
        {
            var _skills = _uow.Repository<Skill>().Get(x => x.IsDeleted == false).OrderByDescending(x => x.SkillID).ToList();
            return View(_skills);
            //return View(new List<Skill>() { new Skill { } });
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var _skill = _uow.Repository<Skill>().Get(x => x.IsDeleted == false && x.SkillID == id).FirstOrDefault();
            return View(_skill);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "Skill")]
        public ActionResult Create(Skill skill)
        {
            try
            {
                skill.CreatedByDate = DateTime.Now;
                skill.CreatedByID = CurrentUser.UserID;
                _uow.Repository<Skill>().Insert(skill);
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
        [AccessAuthenticationFilter(EventAccess = "Edit", InterfaceName = "Skill")]
        public ActionResult Edit(Skill skill)
        {
            try
            {
                var _skill = _uow.Repository<Skill>().Get(x => x.IsDeleted == false && x.SkillID == skill.SkillID).FirstOrDefault();
                _skill.SkillName = skill.SkillName;
                _skill.Remarks = skill.Remarks;
                _skill.updatedByDate = DateTime.Now;
                _skill.UpdatedByID = CurrentUser.UserID;
                _uow.Repository<Skill>().Update(_skill);
                _uow.SaveChanges();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", error = ex.Message });
            }
        }
        
        [HttpPost]
        [AccessAuthenticationFilter(EventAccess = "Delete", InterfaceName = "Skill")]
        public ActionResult Delete(int id)
        {
            try
            {
                var _skill = _uow.Repository<Skill>().Get(x => x.IsDeleted == false && x.SkillID == id).FirstOrDefault();
                _skill.updatedByDate = DateTime.Now;
                _skill.UpdatedByID = CurrentUser.UserID;
                _skill.IsDeleted = true;
                _uow.Repository<Skill>().Update(_skill);
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