using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.Models
{
    public partial class EmployeemanagementContext : DbContext
    {
        public EmployeemanagementContext(DbContextOptions<EmployeemanagementContext> options) : base(options) { }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<ExpensesTitle> ExpensesTitle { get; set; }
        public virtual DbSet<HolidayInfo> HolidayInfo { get; set; }
        public virtual DbSet<HolidayType> HolidayType { get; set; }
        public virtual DbSet<LeaveInfo> LeaveInfo { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequest { get; set; }
        public virtual DbSet<LeaveType> LeaveType { get; set; }
        public virtual DbSet<ManagerInfo> ManagerInfo { get; set; }
        public virtual DbSet<ManagerType> ManagerType { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<OrganizationInfo> OrganizationInfo { get; set; }
        public virtual DbSet<OvertimeDetails> OvertimeDetails { get; set; }
        public virtual DbSet<OvertimeSetUp> OvertimeSetUp { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<SalaryAttribute> SalaryAttribute { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<TotalLeaveDaysForDesignation> TotalLeaveDaysForDesignation { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=Employeemanagement;User Id=sa; Password=L@xmir1n1;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.DateEn)
                    .HasColumnName("Date_En")
                    .HasMaxLength(50);

                entity.Property(e => e.DateNp)
                    .HasColumnName("Date_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.FiscalYear).HasMaxLength(50);

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Attendanc__Emplo__5629CD9C");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.AddressEn)
                    .HasColumnName("Address_En")
                    .HasMaxLength(200);

                entity.Property(e => e.BranchNameEn)
                    .HasColumnName("BranchName_En")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BranchNameNp)
                    .HasColumnName("BranchName_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.ContactNo).HasMaxLength(200);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.EstablishedDate).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Branch)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Branch__Organiza__15502E78");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Alice)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DepartmentNameEn)
                    .HasColumnName("DepartmentName_En")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentNameNp)
                    .HasColumnName("DepartmentName_Np")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Departmen__Branc__1B0907CE");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.Alice).HasMaxLength(10);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DesignationNameEn)
                    .HasColumnName("DesignationName_En")
                    .HasMaxLength(100);

                entity.Property(e => e.DesignationNameNp)
                    .HasColumnName("DesignationName_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.AddressPerEn)
                    .HasColumnName("Address_Per_En")
                    .HasMaxLength(200);

                entity.Property(e => e.AddressPerNp)
                    .HasColumnName("Address_Per_Np")
                    .HasMaxLength(200);

                entity.Property(e => e.AddressTempEn)
                    .HasColumnName("Address_Temp_En")
                    .HasMaxLength(200);

                entity.Property(e => e.AddressTempNp)
                    .HasColumnName("Address_Temp_Np")
                    .HasMaxLength(200);

                entity.Property(e => e.CitizenshipBack)
                    .HasColumnName("Citizenship_Back")
                    .HasMaxLength(50);

                entity.Property(e => e.CitizenshipFront)
                    .HasColumnName("Citizenship_Front")
                    .HasMaxLength(50);

                entity.Property(e => e.CitizenshipNo)
                    .HasColumnName("Citizenship_No")
                    .HasMaxLength(20);

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_No")
                    .HasMaxLength(200);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DobAd)
                    .HasColumnName("DOB_AD")
                    .HasMaxLength(50);

                entity.Property(e => e.DobBs)
                    .HasColumnName("DOB_Bs")
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EmployeeNameEn)
                    .HasColumnName("EmployeeName_En")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeNameNp)
                    .HasColumnName("EmployeeName_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(200);

                entity.Property(e => e.JoinDateEn)
                    .HasColumnName("Join_Date_En")
                    .HasMaxLength(100);

                entity.Property(e => e.JoinDateNp)
                    .HasColumnName("Join_Date_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.LeftDateEn)
                    .HasColumnName("Left_Date_En")
                    .HasMaxLength(100);

                entity.Property(e => e.LeftDateNp)
                    .HasColumnName("Left_Date_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.Nationality).HasMaxLength(20);

                entity.Property(e => e.Photo).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__Employee__Branch__403A8C7D");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__Employee__Depart__4222D4EF");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__Employee__Design__412EB0B6");

                entity.HasOne(d => d.EmployeeTypeNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeType)
                    .HasConstraintName("FK__Employee__Employ__440B1D61");

                entity.HasOne(d => d.ShiftNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Shift)
                    .HasConstraintName("FK__Employee__Shift__4316F928");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.EmployeeTypeTitleEn)
                    .HasColumnName("EmployeeTypeTitle_En")
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeTypeTitleNp)
                    .HasColumnName("EmployeeTypeTitle_Np")
                    .HasMaxLength(20);

                entity.Property(e => e.FiscalYear).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ExpensesTitle>(entity =>
            {
                entity.HasKey(e => e.ExpensesId);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ExpensesTitleEn)
                    .HasColumnName("ExpensesTitle_En")
                    .HasMaxLength(50);

                entity.Property(e => e.ExpensesTitleNp)
                    .HasColumnName("ExpensesTitle_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<HolidayInfo>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DateFromEn)
                    .HasColumnName("DateFrom_En")
                    .HasMaxLength(50);

                entity.Property(e => e.DateFromNp)
                    .HasColumnName("DateFrom_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.DateToEn)
                    .HasColumnName("DateTo_En")
                    .HasMaxLength(50);

                entity.Property(e => e.DateToNp)
                    .HasColumnName("DateTo_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.RemarksEn)
                    .HasColumnName("Remarks_En")
                    .HasMaxLength(500);

                entity.Property(e => e.RemarksNp)
                    .HasColumnName("Remarks_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.HolidayTypeNavigation)
                    .WithMany(p => p.HolidayInfo)
                    .HasForeignKey(d => d.HolidayType)
                    .HasConstraintName("FK__HolidayIn__Holid__239E4DCF");
            });

            modelBuilder.Entity<HolidayType>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.HolidayTitleEn)
                    .HasColumnName("HolidayTitle_En")
                    .HasMaxLength(100);

                entity.Property(e => e.HolidayTitleNp)
                    .HasColumnName("HolidayTitle_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<LeaveInfo>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FiscalYear).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.LeaveInfo)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__LeaveInfo__Desig__2C3393D0");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.LeaveInfo)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK__LeaveInfo__Leave__2B3F6F97");
            });

            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DateFromEn)
                    .HasColumnName("DateFrom_En")
                    .HasMaxLength(50);

                entity.Property(e => e.DateToNp)
                    .HasColumnName("DateTo_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveRequest)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__LeaveRequ__Emplo__5FB337D6");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.LeaveRequest)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK__LeaveRequ__Leave__60A75C0F");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.LeaveTitleEn)
                    .HasColumnName("LeaveTitle_En")
                    .HasMaxLength(100);

                entity.Property(e => e.LeaveTitleNp)
                    .HasColumnName("LeaveTitle_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ManagerInfo>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FicalYear).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ManagerInfo)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__ManagerIn__Emplo__47DBAE45");

                entity.HasOne(d => d.ManagerTypeNavigation)
                    .WithMany(p => p.ManagerInfo)
                    .HasForeignKey(d => d.ManagerType)
                    .HasConstraintName("FK__ManagerIn__Manag__46E78A0C");
            });

            modelBuilder.Entity<ManagerType>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ManagerTitleEn)
                    .HasColumnName("ManagerTitle_En")
                    .HasMaxLength(50);

                entity.Property(e => e.ManagerTitleNp)
                    .HasColumnName("ManagerTitle_Np")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.HasKey(e => e.MonthId);

                entity.Property(e => e.Alice).HasMaxLength(10);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.MonthNameEn)
                    .HasColumnName("MonthName_En")
                    .HasMaxLength(15);

                entity.Property(e => e.MonthNameNp)
                    .HasColumnName("MonthName_Np")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<OrganizationInfo>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.Property(e => e.AddressEn)
                    .HasColumnName("Address_En")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressNp)
                    .HasColumnName("Address_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EstablishedDateEn)
                    .HasColumnName("EstablishedDate_En")
                    .HasMaxLength(100);

                entity.Property(e => e.EstablishedDateNp)
                    .HasColumnName("EstablishedDate_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.OrganizationNameEn)
                    .HasColumnName("OrganizationName_En")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationNameNp)
                    .HasColumnName("OrganizationName_Np")
                    .HasMaxLength(100);

                entity.Property(e => e.PanNo).HasMaxLength(20);

                entity.Property(e => e.Website).HasMaxLength(100);
            });

            modelBuilder.Entity<OvertimeDetails>(entity =>
            {
                entity.Property(e => e.OvertimeDetailsId).HasColumnName("OvertimeDetailsID");

                entity.Property(e => e.AmoutPerHour).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DateEn)
                    .HasColumnName("Date_En")
                    .HasMaxLength(20);

                entity.Property(e => e.DateNp)
                    .HasColumnName("Date_np")
                    .HasMaxLength(20);

                entity.Property(e => e.Hour).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OvertimeDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__OvertimeD__Emplo__5BE2A6F2");
            });

            modelBuilder.Entity<OvertimeSetUp>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FicalYear).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.RatePerHour).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.OvertimeSetUp)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__OvertimeS__Desig__59063A47");
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);

                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.PaymentTypeTitleEn)
                    .HasColumnName("PaymentTypeTitle_En")
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentTypeTitleNp)
                    .HasColumnName("PaymentTypeTitle_Np")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.PaymentTypeEn)
                    .HasColumnName("PaymentType_En")
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentTypeNp)
                    .HasColumnName("PaymentType_Np")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalaryAttribute>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.TitleEn)
                    .HasColumnName("Title_En")
                    .HasMaxLength(50);

                entity.Property(e => e.TitleNp)
                    .HasColumnName("Title_Np")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FiscalYear).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.ShiftTitleEn)
                    .HasColumnName("ShiftTitle_En")
                    .HasMaxLength(20);

                entity.Property(e => e.ShiftTitleNp)
                    .HasColumnName("ShiftTitle_Np")
                    .HasMaxLength(20);

                entity.Property(e => e.TimeFrom).HasMaxLength(50);

                entity.Property(e => e.TimeTo).HasMaxLength(50);
            });

            modelBuilder.Entity<TotalLeaveDaysForDesignation>(entity =>
            {
                entity.Property(e => e.CreateDateEn)
                    .HasColumnName("CreateDate_En")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateDateNp)
                    .HasColumnName("CreateDate_Np")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FiscalYear).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedDateEn)
                    .HasColumnName("ModifiedDate_En")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedDateNp)
                    .HasColumnName("ModifiedDate_Np")
                    .HasMaxLength(500);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.TotalLeaveDaysForDesignation)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__TotalLeav__Desig__286302EC");
            });
        }
    }
}
