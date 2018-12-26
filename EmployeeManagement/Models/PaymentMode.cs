using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class PaymentMode
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitleEn { get; set; }
        public string PaymentTypeTitleNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }
    }
}
