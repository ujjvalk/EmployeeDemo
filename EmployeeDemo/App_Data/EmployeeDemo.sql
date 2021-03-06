USE [EmployeeDemo]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10-01-19 11:41:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[empId] [bigint] IDENTITY(1,1) NOT NULL,
	[fName] [nvarchar](50) NOT NULL,
	[mName] [nvarchar](50) NOT NULL,
	[lName] [nvarchar](50) NOT NULL,
	[age] [smallint] NULL,
	[birthdate] [datetime] NULL,
	[gender] [smallint] NULL,
	[address] [nvarchar](500) NULL,
	[email] [nvarchar](100) NULL,
	[hobby] [nvarchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salary]    Script Date: 10-01-19 11:41:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[salaryId] [bigint] IDENTITY(1,1) NOT NULL,
	[empId] [bigint] NOT NULL,
	[date] [datetime] NOT NULL,
	[sal] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_alary] PRIMARY KEY CLUSTERED 
(
	[salaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
