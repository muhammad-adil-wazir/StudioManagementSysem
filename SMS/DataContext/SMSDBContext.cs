using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SMS.DataContext.Entities;

namespace SMS.DataContext
{
    public class SMSDBContext : DbContext
    {
        public SMSDBContext() : base("SMSDBContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<EnquiryStatus> EnquiryStatus { get; set; }
        public DbSet<EnquiryType> EnquiryTypes { get; set; }
        public DbSet<FunctionType> FunctionTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<ProjectStatus> ProjectStatus{ get; set; }
        public DbSet<Skill> Skills{ get; set; }
        public DbSet<EnquiryDeviceDetail> EnquiryDeviceDetails { get; set; }
        public DbSet<EnquiryEmpDetail> EnquiryEmpDetails { get; set; }
        public DbSet<EnquiryFunctionTypeDetail> EnquiryFunctionTypeDetails { get; set; }
        public DbSet<EnquiryJobDetail> EnquiryJobDetails { get; set; }
        public DbSet<EnquirySkillDetail> EnquirySkillDetails { get; set; }
        public DbSet<EnquiryStatusDetail> EnquiryStatusDetails { get; set; }
        public DbSet<ProjectDeviceDetail> ProjectDeviceDetails { get; set; }
        public DbSet<ProjectEmpDetail> ProjectEmpDetails { get; set; }
        public DbSet<ProjectFunctionTypeDetail> ProjectFunctionTypeDetails { get; set; }
        public DbSet<ProjectJobDetail> ProjectJobDetails { get; set; }
        public DbSet<ProjectSkillDetail> ProjectSkillDetails { get; set; }
        public DbSet<ProjectStatusDetail> ProjectStatusDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EventAccess> EventAccess { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<EmployeeSkillDetail> EmployeeSkillDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}