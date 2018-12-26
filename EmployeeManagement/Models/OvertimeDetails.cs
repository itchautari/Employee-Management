using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class OvertimeDetails
    {
        public int OvertimeDetailsId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? Hour { get; set; }
        public decimal? AmoutPerHour { get; set; }
        public string DateNp { get; set; }
        public string DateEn { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Employee Employee { get; set; }
    }
}
