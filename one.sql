USE [master]
GO
/****** Object:  Database [Employeemanagement]    Script Date: 12/26/2018 04:30:42 PM ******/
CREATE DATABASE [Employeemanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employeemanagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Employeemanagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Employeemanagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Employeemanagement_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Employeemanagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employeemanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employeemanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employeemanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employeemanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employeemanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employeemanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employeemanagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employeemanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employeemanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employeemanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employeemanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employeemanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employeemanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employeemanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employeemanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employeemanagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Employeemanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employeemanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employeemanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employeemanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employeemanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employeemanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employeemanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employeemanagement] SET RECOVERY FULL 
GO
ALTER DATABASE [Employeemanagement] SET  MULTI_USER 
GO
ALTER DATABASE [Employeemanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employeemanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employeemanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employeemanagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Employeemanagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Employeemanagement', N'ON'
GO
USE [Employeemanagement]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[AttendanceFor] [bit] NULL,
	[FiscalYear] [nvarchar](50) NULL,
	[Date_En] [nvarchar](50) NULL,
	[Date_Np] [nvarchar](50) NULL,
	[Time] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Branch]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName_En] [varchar](100) NULL,
	[BranchName_Np] [nvarchar](100) NULL,
	[OrganizationId] [int] NULL,
	[Address_En] [nvarchar](200) NULL,
	[ContactNo] [nvarchar](200) NULL,
	[Email] [nvarchar](500) NULL,
	[EstablishedDate] [nvarchar](100) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName_En] [varchar](100) NULL,
	[DepartmentName_Np] [varchar](100) NULL,
	[Alice] [varchar](10) NULL,
	[BranchId] [int] NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName_En] [nvarchar](100) NULL,
	[DesignationName_Np] [nvarchar](100) NULL,
	[Alice] [nvarchar](10) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName_En] [nvarchar](100) NULL,
	[EmployeeName_Np] [nvarchar](100) NULL,
	[Citizenship_No] [nvarchar](20) NULL,
	[DOB_Bs] [nvarchar](50) NULL,
	[DOB_AD] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Contact_No] [nvarchar](200) NULL,
	[Address_Temp_En] [nvarchar](200) NULL,
	[Address_Temp_Np] [nvarchar](200) NULL,
	[Address_Per_En] [nvarchar](200) NULL,
	[Address_Per_Np] [nvarchar](200) NULL,
	[Gender] [nvarchar](200) NULL,
	[Nationality] [nvarchar](20) NULL,
	[Branch] [int] NULL,
	[Designation] [int] NULL,
	[Department] [int] NULL,
	[Join_Date_En] [nvarchar](100) NULL,
	[Join_Date_Np] [nvarchar](100) NULL,
	[Left_Date_En] [nvarchar](100) NULL,
	[Left_Date_Np] [nvarchar](100) NULL,
	[Shift] [int] NULL,
	[EmployeeType] [int] NULL,
	[Remark] [nvarchar](200) NULL,
	[Photo] [nvarchar](50) NULL,
	[Citizenship_Front] [nvarchar](50) NULL,
	[Citizenship_Back] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[EmployeeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeTypeTitle_En] [nvarchar](20) NULL,
	[EmployeeTypeTitle_Np] [nvarchar](20) NULL,
	[FiscalYear] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpensesTitle]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpensesTitle](
	[ExpensesId] [int] IDENTITY(1,1) NOT NULL,
	[ExpensesTitle_En] [nvarchar](50) NULL,
	[ExpensesTitle_Np] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExpensesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HolidayInfo]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HolidayInfo](
	[HolidayInfoId] [int] IDENTITY(1,1) NOT NULL,
	[HolidayType] [int] NULL,
	[DateFrom_En] [nvarchar](50) NULL,
	[DateTo_En] [nvarchar](50) NULL,
	[DateFrom_Np] [nvarchar](50) NULL,
	[DateTo_Np] [nvarchar](50) NULL,
	[Remarks_En] [nvarchar](500) NULL,
	[Remarks_Np] [nvarchar](500) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[HolidayInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HolidayType]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HolidayType](
	[HolidayTypeId] [int] IDENTITY(1,1) NOT NULL,
	[HolidayTitle_En] [nvarchar](100) NULL,
	[HolidayTitle_Np] [nvarchar](100) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[HolidayTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveInfo]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveInfo](
	[LeaveInfoId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveType] [int] NULL,
	[Designation] [int] NULL,
	[TotalDays] [int] NULL,
	[FiscalYear] [nvarchar](10) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveRequest]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequest](
	[LeaveRequestId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[LeaveType] [int] NULL,
	[DateFrom_En] [nvarchar](50) NULL,
	[DateTo_Np] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[LeaveTypeId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveTitle_En] [nvarchar](100) NULL,
	[LeaveTitle_Np] [nvarchar](100) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManagerInfo]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerInfo](
	[ManagerInfoId] [int] IDENTITY(1,1) NOT NULL,
	[ManagerType] [int] NULL,
	[EmployeeId] [int] NULL,
	[FicalYear] [nvarchar](10) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManagerType]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerType](
	[ManagerTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ManagerTitle_En] [nvarchar](50) NULL,
	[ManagerTitle_Np] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Months]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Months](
	[MonthId] [int] IDENTITY(1,1) NOT NULL,
	[MonthName_En] [nvarchar](15) NULL,
	[MonthName_Np] [nvarchar](15) NULL,
	[Alice] [nvarchar](10) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MonthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrganizationInfo]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganizationInfo](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName_En] [varchar](100) NULL,
	[OrganizationName_Np] [nvarchar](100) NULL,
	[PanNo] [nvarchar](20) NULL,
	[Address_En] [varchar](100) NULL,
	[Address_Np] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](100) NULL,
	[Logo] [nvarchar](200) NULL,
	[EstablishedDate_En] [nvarchar](100) NULL,
	[EstablishedDate_Np] [nvarchar](100) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[ModifiedDate] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OvertimeDetails]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvertimeDetails](
	[OvertimeDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[Hour] [decimal](18, 0) NULL,
	[AmoutPerHour] [decimal](18, 0) NULL,
	[Date_np] [nvarchar](20) NULL,
	[Date_En] [nvarchar](20) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OvertimeDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OvertimeSetUp]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvertimeSetUp](
	[OvertimeSetUpId] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [int] NULL,
	[DaysPerMonth] [int] NULL,
	[HourPerDay] [int] NULL,
	[RatePerHour] [decimal](18, 0) NULL,
	[FicalYear] [nvarchar](10) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OvertimeSetUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMode]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMode](
	[PaymentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentTypeTitle_En] [nvarchar](50) NULL,
	[PaymentTypeTitle_Np] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[PaymentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType_En] [nvarchar](50) NULL,
	[PaymentType_Np] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalaryAttribute]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryAttribute](
	[SalaryAttributeId] [int] IDENTITY(1,1) NOT NULL,
	[Title_En] [nvarchar](50) NULL,
	[Title_Np] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaryAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shift]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[ShiftTitle_En] [nvarchar](20) NULL,
	[ShiftTitle_Np] [nvarchar](20) NULL,
	[TimeFrom] [nvarchar](50) NULL,
	[TimeTo] [nvarchar](50) NULL,
	[FiscalYear] [nvarchar](50) NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TotalLeaveDaysForDesignation]    Script Date: 12/26/2018 04:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TotalLeaveDaysForDesignation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [int] NULL,
	[FiscalYear] [nvarchar](10) NULL,
	[TotalDays] [int] NULL,
	[CreateDate_En] [nvarchar](10) NULL,
	[CreateDate_Np] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDate_En] [nvarchar](500) NULL,
	[ModifiedDate_Np] [nvarchar](500) NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Branch]  WITH CHECK ADD FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[OrganizationInfo] ([OrganizationId])
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Branch])
REFERENCES [dbo].[Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Department])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Designation])
REFERENCES [dbo].[Designation] ([DesignationId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([EmployeeType])
REFERENCES [dbo].[EmployeeType] ([EmployeeTypeId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Shift])
REFERENCES [dbo].[Shift] ([ShiftId])
GO
ALTER TABLE [dbo].[HolidayInfo]  WITH CHECK ADD FOREIGN KEY([HolidayType])
REFERENCES [dbo].[HolidayType] ([HolidayTypeId])
GO
ALTER TABLE [dbo].[LeaveInfo]  WITH CHECK ADD FOREIGN KEY([Designation])
REFERENCES [dbo].[Designation] ([DesignationId])
GO
ALTER TABLE [dbo].[LeaveInfo]  WITH CHECK ADD FOREIGN KEY([LeaveType])
REFERENCES [dbo].[LeaveType] ([LeaveTypeId])
GO
ALTER TABLE [dbo].[LeaveRequest]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[LeaveRequest]  WITH CHECK ADD FOREIGN KEY([LeaveType])
REFERENCES [dbo].[LeaveType] ([LeaveTypeId])
GO
ALTER TABLE [dbo].[ManagerInfo]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[ManagerInfo]  WITH CHECK ADD FOREIGN KEY([ManagerType])
REFERENCES [dbo].[ManagerType] ([ManagerTypeId])
GO
ALTER TABLE [dbo].[OvertimeDetails]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[OvertimeSetUp]  WITH CHECK ADD FOREIGN KEY([Designation])
REFERENCES [dbo].[Designation] ([DesignationId])
GO
ALTER TABLE [dbo].[TotalLeaveDaysForDesignation]  WITH CHECK ADD FOREIGN KEY([Designation])
REFERENCES [dbo].[Designation] ([DesignationId])
GO
USE [master]
GO
ALTER DATABASE [Employeemanagement] SET  READ_WRITE 
GO
