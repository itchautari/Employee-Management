using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentNameEn { get; set; }
        public string DepartmentNameNp { get; set; }
        public string Alice { get; set; }
        public int? BranchId { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Branch Branch { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
