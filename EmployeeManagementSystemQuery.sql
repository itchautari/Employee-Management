
Create Database Employeemanagement
Use Employeemanagement
create table OrganizationInfo(
	OrganizationId int primary key identity(1,1),
	OrganizationName_En nvarchar(100),
	OrganizationName_Np nvarchar(100),
	PanNo nvarchar(20),
	Address_En nvarchar(200),
	Address_Np nvarchar(200),
	ContactNo nvarchar(200),
	Email nvarchar(500),
	Website nvarchar(100),
	Logo nvarchar(200),
	EstablishedDate_En nvarchar(100),
	EstablishedDate_Np nvarchar(100),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table Branch(
	BranchId int primary key identity(1,1),
	BranchName_En nvarchar(100),
	BranchName_Np nvarchar(100),
	OrganizationId int foreign key references OrganizationInfo(OrganizationId),
	Address_En nvarchar(200),
	ContactNo nvarchar(200),
	Email nvarchar(500),
	EstablishedDate nvarchar(100),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table Department(
	DepartmentId int primary key identity(1,1),
	DepartmentName_En nvarchar(100),
	DepartmentName_Np nvarchar(100),
	Alice nvarchar(10),
	BranchId int foreign key references Branch(BranchId),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table Designation(
	DesignationId int primary key identity(1,1),
	DesignationName_En nvarchar(100),
	DesignationName_Np nvarchar(100),
	Alice nvarchar(10),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table FiscalYear(
	FiscalYearId int primary key identity(1,1),
	FiscalYear nvarchar(10),
	Active bit
)

Create table HolidayType(
	HolidayTypeId int primary key identity(1,1),
	HolidayTitle_En nvarchar(100),
	HolidayTitle_Np nvarchar(100),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table HolidayInfo(
	HolidayInfoId int primary key identity(1,1),
	HolidayType int foreign key references HolidayType(HolidayTypeId),
	FiscalYear nvarchar(10),
	DateFrom_En nvarchar(50),
	DateTo_En nvarchar(50),
	DateFrom_Np nvarchar(50),
	DateTo_Np nvarchar(50),
	Remarks_En nvarchar(500),
	Remarks_Np nvarchar(500),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table TotalLeaveDaysForDesignation(
	Id int primary key identity(1,1),
	Designation int foreign key references Designation(DesignationId),
	FiscalYear nvarchar(10),
	TotalDays int,
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table LeaveType(
	LeaveTypeId int primary key identity(1,1),
	LeaveTitle_En nvarchar(100),
	LeaveTitle_Np nvarchar(100),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table LeaveInfo(
	LeaveInfoId int primary key identity(1,1),
	LeaveType int foreign key references LeaveType(LeaveTypeId),
	Designation int foreign key references Designation(DesignationId),
	TotalDays int,
	FiscalYear nvarchar(10),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table Months(
	MonthId int primary key identity(1,1),
	MonthName_En nvarchar(15),
	MonthName_Np nvarchar(15),
	Alice nvarchar(10),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

create table Shift(
	ShiftId int primary key identity(1,1),
	ShiftTitle_En nvarchar(20),
	ShiftTitle_Np nvarchar(20),
	TimeFrom nvarchar(50),
	TimeTo nvarchar(50),
	FiscalYear nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)

create table EmployeeType(
	EmployeeTypeId int primary Key identity (1,1),
	EmployeeTypeTitle_En nvarchar(20),
	EmployeeTypeTitle_Np nvarchar(20),
	FiscalYear nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)

-----hend payment, bank payment-----
create table PaymentMode (
	PaymentModeId int primary key identity (1,1),
	PaymentModeTitle_En nvarchar(50),
	PaymentModeTitle_Np nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)

--daily, hourly, monthly, prokect base
create table PaymentType(
	PaymentTypeId int primary key  identity (1,1),
	PaymentType_En nvarchar(50),
	PaymentType_Np nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)

create table SalaryAttribute(
	SalaryAttributeId int primary key identity(1,1),
	Title_En nvarchar(50),
	Title_Np nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)

create table ExpensesTitle(--- salary,fournitures
	ExpensesId int primary key identity(1,1),
	ExpensesTitle_En nvarchar(50),
	ExpensesTitle_Np nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit,
)


create table Employee(
	EmployeeId int primary key identity(1,1),
	EmployeeName_En nvarchar(100),
	EmployeeName_Np nvarchar(100),
	Citizenship_No nvarchar(20),
	DOB_Bs nvarchar(50),
	DOB_AD nvarchar(50),
	Email nvarchar(100),
	Contact_No nvarchar(200),
	Address_Temp_En nvarchar(200),
	Address_Temp_Np nvarchar(200),
	Address_Per_En nvarchar(200),
	Address_Per_Np nvarchar(200),
	Gender nvarchar(200),
	Nationality nvarchar(20),
	Branch int foreign key references Branch(BranchID),
	Designation int foreign key references Designation(DesignationId),
	Department int foreign key references Department(DepartmentId),
	Join_Date_En nvarchar(100),
	Join_Date_Np nvarchar(100),
	Left_Date_En nvarchar(100),
	Left_Date_Np nvarchar(100),
	Shift int foreign key references shift(shiftId),
	EmployeeType int foreign key references EmployeeType(EmployeeTypeId),
	Remark nvarchar(200),
	Photo nvarchar(50),
	Citizenship_Front nvarchar(50),
	Citizenship_Back nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table ManagerType(
	ManagerTypeId int primary key identity(1,1),
	ManagerTitle_En nvarchar(50),
	ManagerTitle_Np nvarchar(50),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table ManagerInfo(
	ManagerInfoId int primary key identity(1,1),
	ManagerType int foreign key references ManagerType(ManagerTypeId),
	EmployeeId int foreign key references Employee(EmployeeId),
	FicalYear nvarchar(10),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
)

create table Attendance(
	AttendanceId int primary key identity(1,1),
	EmployeeId int foreign key references Employee(EmployeeId),
	AttendanceFor bit,
	FiscalYear nvarchar(50),
	Date_En nvarchar(50),
	Date_Np nvarchar(50),
	Time nvarchar(50),
)

create table OvertimeSetUp(
	OvertimeSetUpId int primary key identity(1,1),
	Designation int foreign key references Designation(DesignationId),
	DaysPerMonth int,
	HourPerDay int,
	RatePerHour decimal,
	FicalYear nvarchar(10),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)
create table OvertimeDetails(
OvertimeDetailsID int primary key identity(1,1),
	EmployeeId int foreign key references Employee(EmployeeId),
	Hour decimal,
	AmoutPerHour decimal,
	Date_np nvarchar(20),
	Date_En nvarchar(20),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Active bit
)

Create table LeaveRequest(
	LeaveRequestId int primary key identity(1,1),
	EmployeeId int foreign key references Employee(EmployeeId),
	LeaveType int foreign key references LeaveType(LeaveTypeId),
	DateFrom_En nvarchar(50),
	DateFrom_Np nvarchar(50),
	DatetTo_En nvarchar(50),
	DateTo_Np nvarchar(50),
	Remark nvarchar(200),
	CreateDate_En nvarchar(10),
	CreateDate_Np nvarchar(10),
	CreatedBy nvarchar(500),
	ModifiedDate_En nvarchar(500),
	ModifiedDate_Np nvarchar(500),
	ModifiedBy nvarchar(500),
	Responce int,
	ResponceBy nvarchar(50),
	ResponceDate_En nvarchar(50),
	ResponceDate_Np nvarchar(50),
	Active bit
)

