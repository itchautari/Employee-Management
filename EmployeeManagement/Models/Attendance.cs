using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? AttendanceFor { get; set; }
        public string FiscalYear { get; set; }
        public string DateEn { get; set; }
        public string DateNp { get; set; }
        public string Time { get; set; }

        public Employee Employee { get; set; }
    }
}
