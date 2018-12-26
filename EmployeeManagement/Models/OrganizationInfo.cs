using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class OrganizationInfo
    {
        public OrganizationInfo()
        {
            Branch = new HashSet<Branch>();
        }

        public int OrganizationId { get; set; }
        public string OrganizationNameEn { get; set; }
        public string OrganizationNameNp { get; set; }
        public string PanNo { get; set; }
        public string AddressEn { get; set; }
        public string AddressNp { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
        public string EstablishedDateEn { get; set; }
        public string EstablishedDateNp { get; set; }
        public string CreateDateEn { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Branch> Branch { get; set; }
    }
}
