using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Months
    {
        public int MonthId { get; set; }
        public string MonthNameEn { get; set; }
        public string MonthNameNp { get; set; }
        public string Alice { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }
    }
}
