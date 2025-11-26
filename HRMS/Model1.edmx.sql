
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/22/2022 09:43:24
-- Generated from EDMX file: G:\Downloads\HRMS_new\HRMS\HRMS\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [hrms];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tbl_emplo__fk_em__6FE99F9F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_employee_salary] DROP CONSTRAINT [FK__tbl_emplo__fk_em__6FE99F9F];
GO
IF OBJECT_ID(N'[dbo].[FK__tbl_loanp__emp_i__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_loanpaidemp] DROP CONSTRAINT [FK__tbl_loanp__emp_i__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_login_tbl_usertype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_login] DROP CONSTRAINT [FK_tbl_login_tbl_usertype];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_dept]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_dept];
GO
IF OBJECT_ID(N'[dbo].[tbl_Document]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Document];
GO
IF OBJECT_ID(N'[dbo].[tbl_emp_attendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_emp_attendance];
GO
IF OBJECT_ID(N'[dbo].[tbl_emp_grade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_emp_grade];
GO
IF OBJECT_ID(N'[dbo].[tbl_emp_holiday]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_emp_holiday];
GO
IF OBJECT_ID(N'[dbo].[tbl_emp_time_set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_emp_time_set];
GO
IF OBJECT_ID(N'[dbo].[tbl_Employe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Employe];
GO
IF OBJECT_ID(N'[dbo].[tbl_employee_conectivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_employee_conectivity];
GO
IF OBJECT_ID(N'[dbo].[tbl_employee_salary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_employee_salary];
GO
IF OBJECT_ID(N'[dbo].[tbl_Employee_status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Employee_status];
GO
IF OBJECT_ID(N'[dbo].[tbl_Employee_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Employee_type];
GO
IF OBJECT_ID(N'[dbo].[tbl_employeeleave]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_employeeleave];
GO
IF OBJECT_ID(N'[dbo].[tbl_holiday]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_holiday];
GO
IF OBJECT_ID(N'[dbo].[tbl_holidays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_holidays];
GO
IF OBJECT_ID(N'[dbo].[tbl_job_descrion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_job_descrion];
GO
IF OBJECT_ID(N'[dbo].[tbl_leave_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_leave_type];
GO
IF OBJECT_ID(N'[dbo].[tbl_leaving_policy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_leaving_policy];
GO
IF OBJECT_ID(N'[dbo].[tbl_loanpaidemp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_loanpaidemp];
GO
IF OBJECT_ID(N'[dbo].[tbl_login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_login];
GO
IF OBJECT_ID(N'[dbo].[tbl_salary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_salary];
GO
IF OBJECT_ID(N'[dbo].[tbl_salary_components]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_salary_components];
GO
IF OBJECT_ID(N'[dbo].[tbl_salary_detuction_policy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_salary_detuction_policy];
GO
IF OBJECT_ID(N'[dbo].[tbl_sub_dept]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_sub_dept];
GO
IF OBJECT_ID(N'[dbo].[tbl_usertype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_usertype];
GO
IF OBJECT_ID(N'[dbo].[tbl_world_country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_world_country];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbl_Document'
CREATE TABLE [dbo].[tbl_Document] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [documentName] nvarchar(250)  NULL,
    [DocumentURL] nvarchar(250)  NULL,
    [UserType] bigint  NULL,
    [Parent] bigint  NULL,
    [Sequence] bigint  NULL,
    [icon] nvarchar(250)  NULL,
    [Application_type] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_login'
CREATE TABLE [dbo].[tbl_login] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [username] nvarchar(50)  NULL,
    [password] nvarchar(50)  NULL,
    [Email] nvarchar(150)  NULL,
    [User_type] bigint  NULL,
    [Desgination] nvarchar(50)  NULL,
    [Contact] nvarchar(50)  NULL,
    [Active_status] bit  NULL
);
GO

-- Creating table 'tbl_usertype'
CREATE TABLE [dbo].[tbl_usertype] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Usertype] nvarchar(50)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_dept'
CREATE TABLE [dbo].[tbl_dept] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Department_name] nvarchar(50)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'tbl_Employee_type'
CREATE TABLE [dbo].[tbl_Employee_type] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Emp_type_name] nvarchar(50)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_sub_dept'
CREATE TABLE [dbo].[tbl_sub_dept] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Sub_department_name] nvarchar(50)  NULL,
    [fk_dept_id] bigint  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_Employee_status'
CREATE TABLE [dbo].[tbl_Employee_status] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Employee_status_name] nvarchar(50)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_job_descrion'
CREATE TABLE [dbo].[tbl_job_descrion] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Designation] nvarchar(50)  NULL,
    [Job_description] nvarchar(1000)  NULL,
    [salary_range_min] decimal(18,0)  NULL,
    [salary_range_max] decimal(18,0)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_leave_type'
CREATE TABLE [dbo].[tbl_leave_type] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [leave_type_name] nvarchar(50)  NULL,
    [status] bit  NULL,
    [total_in_year] int  NULL
);
GO

-- Creating table 'tbl_salary_components'
CREATE TABLE [dbo].[tbl_salary_components] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [salary_components] nvarchar(50)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_Employe'
CREATE TABLE [dbo].[tbl_Employe] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [EmployeeCode] nvarchar(50)  NULL,
    [FirstName] nvarchar(150)  NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [CNIC] nvarchar(50)  NULL,
    [FatherFullName] nvarchar(500)  NULL,
    [FatherCNIC] nvarchar(50)  NULL,
    [Nationality] nvarchar(50)  NULL,
    [Dateofbirth] datetime  NULL,
    [Gender] nvarchar(50)  NULL,
    [MaritalStatus] nvarchar(50)  NULL,
    [Accomodation] nvarchar(50)  NULL,
    [ResidenceAddress] nvarchar(500)  NULL,
    [City] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [MobilePhone] nvarchar(50)  NULL,
    [WorkPhone] nvarchar(50)  NULL,
    [WorkEmail] nvarchar(150)  NULL,
    [PersonalEmail] nvarchar(150)  NULL,
    [HomeAddress1] nvarchar(500)  NULL,
    [HomeAddress2] nvarchar(500)  NULL,
    [EmergencyContactName] nvarchar(150)  NULL,
    [EmergencyRelation] nvarchar(50)  NULL,
    [EmergencyHomePhone] nvarchar(50)  NULL,
    [EmergencyWorkPhone] nvarchar(50)  NULL,
    [EmergencyMobile] nvarchar(50)  NULL,
    [inserteddatetime] datetime  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_leaving_policy'
CREATE TABLE [dbo].[tbl_leaving_policy] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Leavepolicy] nvarchar(50)  NULL,
    [col_1] decimal(18,0)  NULL,
    [col_2] decimal(18,0)  NULL,
    [col_3] decimal(18,0)  NULL,
    [col_4] decimal(18,0)  NULL,
    [col_5] decimal(18,0)  NULL,
    [col_6] decimal(18,0)  NULL,
    [col_7] decimal(18,0)  NULL,
    [Note] nvarchar(250)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_emp_grade'
CREATE TABLE [dbo].[tbl_emp_grade] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [Empgrade] nvarchar(50)  NULL,
    [Note] nvarchar(1500)  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_employee_conectivity'
CREATE TABLE [dbo].[tbl_employee_conectivity] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [employe_fk] bigint  NULL,
    [Dept_fk] bigint  NULL,
    [SubDept_fk] bigint  NULL,
    [jobtitle_fk] bigint  NULL,
    [Joindate] datetime  NULL,
    [Confirmationdate] datetime  NULL,
    [grade_fk] bigint  NULL,
    [Supervisor_fk] bigint  NULL,
    [TerminationDate] datetime  NULL,
    [Notes] nvarchar(500)  NULL,
    [fk_bank_details] bigint  NULL,
    [Emplyeestatus_fk] bigint  NULL,
    [ContractStartDate] datetime  NULL,
    [ContractEndDate] datetime  NULL,
    [inserteddatetime] datetime  NULL,
    [insertedby] bigint  NULL,
    [updatedatetime] datetime  NULL,
    [updateby] bigint  NULL,
    [status] bit  NULL,
    [userid_fk] bigint  NULL
);
GO

-- Creating table 'tbl_emp_attendance'
CREATE TABLE [dbo].[tbl_emp_attendance] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [fk_emp] bigint  NULL,
    [fk_emp_time_set] bigint  NULL,
    [date] datetime  NULL,
    [time] time  NULL,
    [Type] nvarchar(50)  NULL,
    [inserteddatetime] datetime  NULL,
    [status] bit  NULL,
    [late] bit  NULL,
    [working_hours] float  NULL,
    [leave] bit  NULL,
    [month] int  NULL,
    [year] int  NULL
);
GO

-- Creating table 'tbl_emp_time_set'
CREATE TABLE [dbo].[tbl_emp_time_set] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [timeIN] time  NULL,
    [timeout] time  NULL,
    [status] bit  NULL,
    [fk_grade_id] bigint  NULL
);
GO

-- Creating table 'tbl_employee_salary'
CREATE TABLE [dbo].[tbl_employee_salary] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [fk_employee_id] bigint  NULL,
    [amount] bigint  NULL,
    [status] bit  NULL,
    [salary_component] varchar(50)  NULL
);
GO

-- Creating table 'tbl_loanpaidemp'
CREATE TABLE [dbo].[tbl_loanpaidemp] (
    [loan_id] bigint IDENTITY(1,1) NOT NULL,
    [emp_id] bigint  NOT NULL,
    [loan_amount] bigint  NOT NULL,
    [payabletime_in_month] int  NOT NULL,
    [remaining_loan_amount] int  NOT NULL,
    [applied_from] varchar(50)  NOT NULL,
    [Status] char(10)  NULL,
    [payable_amount_per_month] bigint  NULL,
    [remaining_month_payable] int  NULL
);
GO

-- Creating table 'tbl_world_country'
CREATE TABLE [dbo].[tbl_world_country] (
    [id] bigint  NOT NULL,
    [country_name] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_salary_detuction_policy'
CREATE TABLE [dbo].[tbl_salary_detuction_policy] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [late_detuction] nvarchar(50)  NOT NULL,
    [absent_detuction] nvarchar(50)  NULL,
    [Status] bit  NULL,
    [fk_emp_grade] bigint  NULL
);
GO

-- Creating table 'tbl_salary'
CREATE TABLE [dbo].[tbl_salary] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [fk_emp_id] bigint  NOT NULL,
    [salary_month] varchar(20)  NOT NULL,
    [salary_year] varchar(20)  NOT NULL,
    [stat_bonus] float  NULL,
    [gross_earning_amount] float  NOT NULL,
    [gross_deduction_amount] float  NOT NULL,
    [net_pay] float  NOT NULL,
    [inserted_by] bigint  NOT NULL
);
GO

-- Creating table 'tbl_employeeleave'
CREATE TABLE [dbo].[tbl_employeeleave] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [fk_empid] bigint  NULL,
    [fk_leavetypeid] bigint  NULL,
    [Date] datetime  NULL,
    [status] bit  NULL
);
GO

-- Creating table 'tbl_holiday'
CREATE TABLE [dbo].[tbl_holiday] (
    [id] int IDENTITY(1,1) NOT NULL,
    [weekly] int  NULL,
    [yearly] int  NULL,
    [one_time] int  NULL,
    [holiday_day] int  NULL,
    [holiday_date] datetime  NULL,
    [grade_id] int  NOT NULL
);
GO

-- Creating table 'tbl_holidays'
CREATE TABLE [dbo].[tbl_holidays] (
    [id] int IDENTITY(1,1) NOT NULL,
    [weekly] bit  NULL,
    [yearly] bit  NULL,
    [one_time] bit  NULL,
    [holiday_day] int  NULL,
    [holiday_date] datetime  NULL,
    [grade_id] int  NOT NULL
);
GO

-- Creating table 'tbl_emp_holiday'
CREATE TABLE [dbo].[tbl_emp_holiday] (
    [id] int IDENTITY(1,1) NOT NULL,
    [repeat_time] int  NOT NULL,
    [holiday_day] int  NULL,
    [holiday_date] datetime  NULL,
    [grade_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'tbl_Document'
ALTER TABLE [dbo].[tbl_Document]
ADD CONSTRAINT [PK_tbl_Document]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_login'
ALTER TABLE [dbo].[tbl_login]
ADD CONSTRAINT [PK_tbl_login]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_usertype'
ALTER TABLE [dbo].[tbl_usertype]
ADD CONSTRAINT [PK_tbl_usertype]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_dept'
ALTER TABLE [dbo].[tbl_dept]
ADD CONSTRAINT [PK_tbl_dept]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_Employee_type'
ALTER TABLE [dbo].[tbl_Employee_type]
ADD CONSTRAINT [PK_tbl_Employee_type]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_sub_dept'
ALTER TABLE [dbo].[tbl_sub_dept]
ADD CONSTRAINT [PK_tbl_sub_dept]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_Employee_status'
ALTER TABLE [dbo].[tbl_Employee_status]
ADD CONSTRAINT [PK_tbl_Employee_status]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_job_descrion'
ALTER TABLE [dbo].[tbl_job_descrion]
ADD CONSTRAINT [PK_tbl_job_descrion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_leave_type'
ALTER TABLE [dbo].[tbl_leave_type]
ADD CONSTRAINT [PK_tbl_leave_type]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_salary_components'
ALTER TABLE [dbo].[tbl_salary_components]
ADD CONSTRAINT [PK_tbl_salary_components]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_Employe'
ALTER TABLE [dbo].[tbl_Employe]
ADD CONSTRAINT [PK_tbl_Employe]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_leaving_policy'
ALTER TABLE [dbo].[tbl_leaving_policy]
ADD CONSTRAINT [PK_tbl_leaving_policy]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_emp_grade'
ALTER TABLE [dbo].[tbl_emp_grade]
ADD CONSTRAINT [PK_tbl_emp_grade]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_employee_conectivity'
ALTER TABLE [dbo].[tbl_employee_conectivity]
ADD CONSTRAINT [PK_tbl_employee_conectivity]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_emp_attendance'
ALTER TABLE [dbo].[tbl_emp_attendance]
ADD CONSTRAINT [PK_tbl_emp_attendance]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_emp_time_set'
ALTER TABLE [dbo].[tbl_emp_time_set]
ADD CONSTRAINT [PK_tbl_emp_time_set]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_employee_salary'
ALTER TABLE [dbo].[tbl_employee_salary]
ADD CONSTRAINT [PK_tbl_employee_salary]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [loan_id] in table 'tbl_loanpaidemp'
ALTER TABLE [dbo].[tbl_loanpaidemp]
ADD CONSTRAINT [PK_tbl_loanpaidemp]
    PRIMARY KEY CLUSTERED ([loan_id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_world_country'
ALTER TABLE [dbo].[tbl_world_country]
ADD CONSTRAINT [PK_tbl_world_country]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_salary_detuction_policy'
ALTER TABLE [dbo].[tbl_salary_detuction_policy]
ADD CONSTRAINT [PK_tbl_salary_detuction_policy]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_salary'
ALTER TABLE [dbo].[tbl_salary]
ADD CONSTRAINT [PK_tbl_salary]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_employeeleave'
ALTER TABLE [dbo].[tbl_employeeleave]
ADD CONSTRAINT [PK_tbl_employeeleave]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_holiday'
ALTER TABLE [dbo].[tbl_holiday]
ADD CONSTRAINT [PK_tbl_holiday]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_holidays'
ALTER TABLE [dbo].[tbl_holidays]
ADD CONSTRAINT [PK_tbl_holidays]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'tbl_emp_holiday'
ALTER TABLE [dbo].[tbl_emp_holiday]
ADD CONSTRAINT [PK_tbl_emp_holiday]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_type] in table 'tbl_login'
ALTER TABLE [dbo].[tbl_login]
ADD CONSTRAINT [FK_tbl_login_tbl_usertype]
    FOREIGN KEY ([User_type])
    REFERENCES [dbo].[tbl_usertype]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_login_tbl_usertype'
CREATE INDEX [IX_FK_tbl_login_tbl_usertype]
ON [dbo].[tbl_login]
    ([User_type]);
GO

-- Creating foreign key on [fk_employee_id] in table 'tbl_employee_salary'
ALTER TABLE [dbo].[tbl_employee_salary]
ADD CONSTRAINT [FK__tbl_emplo__fk_em__6FE99F9F]
    FOREIGN KEY ([fk_employee_id])
    REFERENCES [dbo].[tbl_Employe]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbl_emplo__fk_em__6FE99F9F'
CREATE INDEX [IX_FK__tbl_emplo__fk_em__6FE99F9F]
ON [dbo].[tbl_employee_salary]
    ([fk_employee_id]);
GO

-- Creating foreign key on [emp_id] in table 'tbl_loanpaidemp'
ALTER TABLE [dbo].[tbl_loanpaidemp]
ADD CONSTRAINT [FK__tbl_loanp__emp_i__49C3F6B7]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[tbl_Employe]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbl_loanp__emp_i__49C3F6B7'
CREATE INDEX [IX_FK__tbl_loanp__emp_i__49C3F6B7]
ON [dbo].[tbl_loanpaidemp]
    ([emp_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------