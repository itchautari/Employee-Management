using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class HolidayInfo
    {
        public int HolidayInfoId { get; set; }
        public int? HolidayType { get; set; }
        public string DateFromEn { get; set; }
        public string DateToEn { get; set; }
        public string DateFromNp { get; set; }
        public string DateToNp { get; set; }
        public string RemarksEn { get; set; }
        public string RemarksNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public HolidayType HolidayTypeNavigation { get; set; }
    }
}
