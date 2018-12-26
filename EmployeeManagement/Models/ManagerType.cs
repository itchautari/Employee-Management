using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class ManagerType
    {
        public ManagerType()
        {
            ManagerInfo = new HashSet<ManagerInfo>();
        }

        public int ManagerTypeId { get; set; }
        public string ManagerTitleEn { get; set; }
        public string ManagerTitleNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public ICollection<ManagerInfo> ManagerInfo { get; set; }
    }
}
