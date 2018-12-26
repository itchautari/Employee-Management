using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            LeaveInfo = new HashSet<LeaveInfo>();
            LeaveRequest = new HashSet<LeaveRequest>();
        }

        public int LeaveTypeId { get; set; }
        public string LeaveTitleEn { get; set; }
        public string LeaveTitleNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public ICollection<LeaveInfo> LeaveInfo { get; set; }
        public ICollection<LeaveRequest> LeaveRequest { get; set; }
    }
}
