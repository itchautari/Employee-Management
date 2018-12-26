using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Shift
    {
        public Shift()
        {
            Employee = new HashSet<Employee>();
        }

        public int ShiftId { get; set; }
        public string ShiftTitleEn { get; set; }
        public string ShiftTitleNp { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string FiscalYear { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
