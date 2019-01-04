using EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

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
        //string _Logo;
        //public string Logo{
        //    get {
        //        string base64String = "";
        //        if(_Logo != null && _Logo != "")
        //        {
        //            base64String = ImageHandler.ImageToBase64(_Logo);
        //        }
        //        return base64String;
        //    }
        //    set {
        //        this._Logo = value;
        //    }
        //}
        public string EstablishedDateEn { get; set; }
        public string EstablishedDateNp { get; set; }
        public string CreateDateEn { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Branch> Branch { get; set; }
    }
}
