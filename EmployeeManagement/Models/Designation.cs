using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
            LeaveInfo = new HashSet<LeaveInfo>();
            OvertimeSetUp = new HashSet<OvertimeSetUp>();
            TotalLeaveDaysForDesignation = new HashSet<TotalLeaveDaysForDesignation>();
        }

        public int DesignationId { get; set; }
        public string DesignationNameEn { get; set; }
        public string DesignationNameNp { get; set; }
        public string Alice { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<LeaveInfo> LeaveInfo { get; set; }
        public ICollection<OvertimeSetUp> OvertimeSetUp { get; set; }
        public ICollection<TotalLeaveDaysForDesignation> TotalLeaveDaysForDesignation { get; set; }
    }
}
