using SMS.DataContext.Entities;
using SMS.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Common;
using SMS.Models;

namespace SMS.Controllers
{
    public class HomeController : Controller
    { 
        // GET: Home
        private UnitOfWork _uow;
        public HomeController(UnitOfWork uow)
        {
            _uow = uow;
        }
        [Authorize]
        public ActionResult Index()
        {
            var _enquiries = _uow.Repository<Enquiry>().Get(x => x.IsDeleted == false);
            var _enquiryCount = _enquiries.Count;
            var _projects = _uow.Repository<Project>().Get(x => x.ProjectDate.Year == DateTime.Now.Year && x.IsDeleted == false);
            var _upcomingProjects = _projects.Where(x => x.ProjectStartDate > DateTime.Now.AddDays(-8));
            Session["UpComingProject"] = Newtonsoft.Json.JsonConvert.SerializeObject(_upcomingProjects);
            var _endingProjects = _projects.Where(x => x.ProjectEndDate > DateTime.Now.AddDays(-8));
            Session["EndingProject"] = Newtonsoft.Json.JsonConvert.SerializeObject(_endingProjects);
            var _projectsCount = _projects.Count;
            var _deviceCount = _uow.Repository<Device>().Get(x => x.CreatedByDate.Year == DateTime.Now.Year && x.IsDeleted == false).Count;
            var _enquiriesLastOneYear = _enquiries.Where(x => x.EnquiryDate > DateTime.Now.AddMonths(-11));
            var _enquiriesChart = new List<Chart>();
            for (int m = 11,k = 0; k < 12; k++,m--)
            {
                int i = DateTime.Now.AddMonths(-m).Month;
                _enquiriesChart.Add(new Chart { Month = i, Count = _enquiriesLastOneYear.Count(p => p.EnquiryDate.Month == i) });
            }
            //var _enquiriesChart = Enumerable.Range(1, 12).Select(x => new Chart  { Month = x, Count = _enquiriesLastOneYear.Count(p => p.EnquiryDate.Month == x) }).ToList();
            var _projectsLastOneYear = _projects.Where(x => x.ProjectDate > DateTime.Now.AddMonths(-11)).ToList();
            var _projectEnquiryIDs = _projects.Select(x => x.EnquiryID);
            var _enquiryActiveCount = _enquiries.Count(x => x.EnquiryStatusID != "EnquiryStatusCancelled".GetConfigByKey<int>() && !_projectEnquiryIDs.Contains(x.EnquiryID));
            // var _issueDocuments = _enquiriesLastSixMonth.GroupBy(e => e.DocumentIssueDate,
            //e => e.DocumentID,
            //(date, total) => new { TotalIssueDocuemnts = total.Count(), Month = date.Month, });


            //var _projectsChart = Enumerable.Range(1, 12).Select(x=> new Chart { Month = x , Count = _projectsLastOneYear.Count(p=>p.ProjectDate.Month == x) }).ToList();
            var _projectsChart = new List<Chart>();
            for (int m = 11, k = 0; k < 12; k++, m--)
            {
                int i = DateTime.Now.AddMonths(-m).Month;
                _projectsChart.Add(new Chart { Month = i, Count = _projectsLastOneYear.Count(p => p.ProjectDate.Month == i) });
            }
            var _projectActiveCount = _projects.Count(x => x.ProjectStatusID != "ProjectStatusCompleted".GetConfigByKey<int>());
            return View(new DashboardModel { DeviceCount = _deviceCount , Enquiries = _enquiriesChart , EnquiryActiveCount = _enquiryActiveCount , EnquiryCount = _enquiryCount , ProjectActiveCount = _projectActiveCount , ProjectCount = _projectsCount , Projects = _projectsChart  });
        }
        public ActionResult UnAuthorized()
        {
            return View("~/Views/Shared/_403.cshtml");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}