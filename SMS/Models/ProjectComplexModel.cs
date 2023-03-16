using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ProjectComplexModel
    {
        public List<ProjectStatus> ProjectStatus { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Device> Devices { get; set; }
        public List<FunctionType> FunctionTypes { get; set; }
        public List<EmployeeSkillDetail> EmployeeSkills { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectDeviceDetail> ProjectDevices { get; set; }
        public List<ProjectDeviceDetail> OnGoingProjectDevices { get; set; }
        public List<ProjectEmpDetail> ProjectEmployees { get; set; }
        //public List<ProjectFunctionTypeDetail> ProjectFunctionTypes { get; set; }
        public List<ProjectJobDetail> ProjectJobs { get; set; }
        public List<ProjectSkillDetail> ProjectSkills { get; set; }
        public List<ProjectStatusDetail> ProjectStatusDetails { get; set; }
        public List<Enquiry> Enquiries { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }
        public Project Project { get; set; }
    }
}