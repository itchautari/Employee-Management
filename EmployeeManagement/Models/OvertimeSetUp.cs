using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class OvertimeSetUp
    {
        public int OvertimeSetUpId { get; set; }
        public int? Designation { get; set; }
        public int? DaysPerMonth { get; set; }
        public int? HourPerDay { get; set; }
        public decimal? RatePerHour { get; set; }
        public string FicalYear { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Designation DesignationNavigation { get; set; }
    }
}
