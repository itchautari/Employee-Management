using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Department = new HashSet<Department>();
            Employee = new HashSet<Employee>();
        }

        public int BranchId { get; set; }
        public string BranchNameEn { get; set; }
        public string BranchNameNp { get; set; }
        public int? OrganizationId { get; set; }
        public string AddressEn { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string EstablishedDate { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public OrganizationInfo Organization { get; set; }
        public ICollection<Department> Department { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
