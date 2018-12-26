using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int? EmployeeId { get; set; }
        public int? LeaveType { get; set; }
        public string DateFromEn { get; set; }
        public string DateToNp { get; set; }
        public string Remark { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Employee Employee { get; set; }
        public LeaveType LeaveTypeNavigation { get; set; }
    }
}
