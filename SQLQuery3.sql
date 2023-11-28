CREATE TABLE [dbo].[TeacherDetails]
(
	[Teacher Id] NVARCHAR (13) NOT NULL,
	[Teacher Name] VARCHAR (25) NOT NULL,
	[Gender] VARCHAR (10) NOT NULL,
	[Course] VARCHAR (25) NOT NULL,
	[Department] VARCHAR (25) NOT NULL,
	[Contact Number] NVARCHAR (10) NOT NULL,
	PRIMARY KEY CLUSTERED ([Teacher Id] ASC)
);