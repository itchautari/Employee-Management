using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class LeaveInfo
    {
        public int LeaveInfoId { get; set; }
        public int? LeaveType { get; set; }
        public int? Designation { get; set; }
        public int? TotalDays { get; set; }
        public string FiscalYear { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Designation DesignationNavigation { get; set; }
        public LeaveType LeaveTypeNavigation { get; set; }
    }
}
