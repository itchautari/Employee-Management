using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class HolidayType
    {
        public HolidayType()
        {
            HolidayInfo = new HashSet<HolidayInfo>();
        }

        public int HolidayTypeId { get; set; }
        public string HolidayTitleEn { get; set; }
        public string HolidayTitleNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public ICollection<HolidayInfo> HolidayInfo { get; set; }
    }
}
