using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Attendance = new HashSet<Attendance>();
            LeaveRequest = new HashSet<LeaveRequest>();
            ManagerInfo = new HashSet<ManagerInfo>();
            OvertimeDetails = new HashSet<OvertimeDetails>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeNameEn { get; set; }
        public string EmployeeNameNp { get; set; }
        public string CitizenshipNo { get; set; }
        public string DobBs { get; set; }
        public string DobAd { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string AddressTempEn { get; set; }
        public string AddressTempNp { get; set; }
        public string AddressPerEn { get; set; }
        public string AddressPerNp { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int? Branch { get; set; }
        public int? Designation { get; set; }
        public int? Department { get; set; }
        public string JoinDateEn { get; set; }
        public string JoinDateNp { get; set; }
        public string LeftDateEn { get; set; }
        public string LeftDateNp { get; set; }
        public int? Shift { get; set; }
        public int? EmployeeType { get; set; }
        public string Remark { get; set; }
        public string Photo { get; set; }
        public string CitizenshipFront { get; set; }
        public string CitizenshipBack { get; set; }
        public string CreateDateEn { get; set; }
        public string CreateDateNp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDateEn { get; set; }
        public string ModifiedDateNp { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }

        public Branch BranchNavigation { get; set; }
        public Department DepartmentNavigation { get; set; }
        public Designation DesignationNavigation { get; set; }
        public EmployeeType EmployeeTypeNavigation { get; set; }
        public Shift ShiftNavigation { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<LeaveRequest> LeaveRequest { get; set; }
        public ICollection<ManagerInfo> ManagerInfo { get; set; }
        public ICollection<OvertimeDetails> OvertimeDetails { get; set; }
    }
}
