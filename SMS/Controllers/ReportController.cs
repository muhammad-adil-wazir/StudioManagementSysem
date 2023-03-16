using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SMS.Common;
using SMS.DataContext.Entities;
using SMS.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class ReportController : Controller
    {
        private IUnitOfWork _uow;
        public ReportController(IUnitOfWork _unitOfWork)
        {
            this._uow = _unitOfWork;
        }
        // GET: Report
        public ActionResult Index(string name)
        {
            TempData["ReportName"] = name;
            return View();
        }
        public void ShowReport(string Name, string StartDate = "", string EndDate = "", string ContractNumber = "",int EnquiryID = 0)
        {
            ReportDocument cryRpt = GetReport(Name, StartDate, EndDate, ContractNumber,EnquiryID);
            //if (Name.ToLower().Contains("payslip"))
            //{
            //    int[] _employeeIds = null;
            //    if (CompanyID > -1)
            //    {
            //        var _employees = _employeeService.Get(e => e.CompanyID == CompanyID).ToList();
            //        if (_employees != null)
            //        {
            //            _employeeIds = _employees.Select(e => Convert.ToInt32(e.EmployeeID)).ToArray();
            //        }
            //    }
            //    else if (EmployeeIds != null && EmployeeIds != "")
            //    {
            //        _employeeIds = EmployeeIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            //    }
            //    if (_employeeIds != null)
            //    {
            //        cryRpt.SetParameterValue("EmployeeID", _employeeIds);
            //    }
            //}
            //if (Name.ToLower().Contains("salaryschedule"))
            //{
            //    cryRpt.SetParameterValue("CompanyName", CompanyName);
            //}
            cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
            cryRpt.Close();
        }
        public bool SendEmail(string Name, string StartDate, string EndDate, int CompanyID, List<int> EmployeeIds)
        {
            var _employees = _uow.Repository<Employee>().Get(e => e.IsDeleted == false).ToList();
            int[] _employeeIds = null;
            if (CompanyID > -1)
            {
                _employees = _employees.Where(e => e.CompanyID == CompanyID).ToList();
                if (_employees != null)
                {
                    _employeeIds = _employees.Select(e => Convert.ToInt32(e.EmployeeID)).ToArray();
                }
            }
            else if (EmployeeIds != null)
            {
                if (EmployeeIds.Count > 0)
                {
                    _employeeIds = EmployeeIds.ToArray();
                }
            }
            if (_employeeIds != null)
            {
                for (int i = 0; i < EmployeeIds.Count; i++)
                {
                    ReportDocument cryRpt = GetReport(Name, StartDate, EndDate);
                    cryRpt.SetParameterValue("EmployeeID", EmployeeIds[i]);
                    //var _tmpReportPath = "TempReportPath".GetConfigByKey<string>();
                    var _tmpReportPath = Server.MapPath("~/Reports");
                    if (System.IO.File.Exists(_tmpReportPath))
                        System.IO.File.Delete(_tmpReportPath);
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, _tmpReportPath);
                    if (cryRpt.Rows.Count > 0)
                    {
                        Utilities.SendEmail(
                              "Payslip",
                              "Please Download the Payslip in the attachement",
                              "SenderEmail".GetConfigByKey<string>(),
                              "SenderPassword".GetConfigByKey<string>(),
                              _employees.Where(e => e.EmployeeID == EmployeeIds[i]).Select(e => e.Email).FirstOrDefault(),
                              _tmpReportPath
                              );
                    }
                    cryRpt.Close();
                    //cryRpt.SaveAs("~/Content/Documents/test repost" + ids + ".pdf");
                    // cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
                }
                return true;
            }
            else
                return false;


            //cryRpt.PrintToPrinter(2, true, 1, 2);
            //using (ReportClass rptH = new ReportClass())
            //{
            //    rptH.FileName = Server.MapPath("~/") + "//Reports//Company.rpt";
            //    rptH.Load();
            //    rptH.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
            //}
        }
        public ReportDocument GetReport(string Name, string StartDate, string EndDate, string ContractNumber = "",int EnquiryID = 0)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath("~/") + "//Reports//" + Name + ".rpt");
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            crConnectionInfo.ServerName = "ServerName".GetConfigByKey<string>();
            crConnectionInfo.DatabaseName = "DatabaseName".GetConfigByKey<string>();
            var _userID = "UserID".GetConfigByKey<string>();
            if (_userID == null || _userID == "")
            {
                crConnectionInfo.IntegratedSecurity = true;
            }
            else
            {
                crConnectionInfo.UserID = _userID;
                crConnectionInfo.Password = "Password".GetConfigByKey<string>();
            }
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            cryRpt.Refresh();
            if(Name.ToLower().Contains("enquiryreceipt"))
            {
                cryRpt.SetParameterValue("EnquiryID", EnquiryID);
            }
            else
            {
                if (Name.ToLower().Contains("contract"))
                {
                    cryRpt.SetParameterValue("ContractNumber", ContractNumber);
                }
                cryRpt.SetParameterValue("StartDate", StartDate);
                cryRpt.SetParameterValue("EndDate", EndDate);
            }
            return cryRpt;
        }
    }
}