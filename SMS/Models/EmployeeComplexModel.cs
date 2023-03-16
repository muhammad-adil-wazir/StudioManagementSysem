using SMS.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class EmployeeComplexModel
    {
        public List<Employee> Employees { get; set; }
        public List<BankAccountType> BankAccountTypes { get; set; }
        public List<Bank> Banks { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<Designation> Designations { get; set; }
        public List<Department> Departments { get; set; }
        public List<Nationality> Nationalities { get; set; }
        public List<Country> Countries { get; set; }
        public List<Company> Companies { get; set; }
        public List<Skill> Skills { get; set; }
        public List<EmployeeSkillDetail> EmployeeSkills { get; set; }

    }
}