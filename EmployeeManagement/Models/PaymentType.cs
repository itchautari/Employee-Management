﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeEn { get; set; }
        public string PaymentTypeNp { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }
    }
}
