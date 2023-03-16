using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class EnquiryComplexModel
    {
        public CustomerComplexModel CustomerModel { get; set; }
        public List<Employee> Employees { get; set; }
        public List<EmployeeSkillDetail> EmployeeSkills { get; set; }
        public List<EnquiryStatus> EnquiryStatus { get; set; }
        public List<EnquiryType> EnquiryTypes { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Device> Devices { get; set; }
        public List<FunctionType> FunctionTypes { get; set; }
        public List<Skill> Skills { get; set; }
        public List<EnquiryDeviceDetail> EnquiryDevices { get; set; }
        public List<EnquiryEmpDetail> EnquiryEmployees { get; set; }
        public List<EnquiryFunctionTypeDetail> EnquiryFunctionTypes { get; set; }
        public List<EnquiryJobDetail> EnquiryJobs { get; set; }
        public List<EnquirySkillDetail> EnquirySkills { get; set; }
        public List<EnquiryStatusDetail> EnquiryStatusDetails { get; set; }
        public List<Enquiry> Enquiries { get; set; }
        public Enquiry Enquiry { get; set; }
    }
}