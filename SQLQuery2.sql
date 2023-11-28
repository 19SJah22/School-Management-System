CREATE TABLE [dbo].[StudentDetails]
(
	[Student Id] NVARCHAR (13) NOT NULL,
	[Student Name] VARCHAR (25) NOT NULL,
	[Gender] VARCHAR (10) NOT NULL,
	[Course Enrollment] VARCHAR (25) NOT NULL,
	[Contact Number] NVARCHAR (10) NOT NULL,
	[Address] VARCHAR (30) NOT NULL,
	PRIMARY KEY CLUSTERED ([Student Id] ASC)
);