using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class ManagerInfo
    {
        public int ManagerInfoId { get; set; }
        public int? ManagerType { get; set; }
        public int? EmployeeId { get; set; }
        public string FicalYear { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }

        public Employee Employee { get; set; }
        public ManagerType ManagerTypeNavigation { get; set; }
    }
}
