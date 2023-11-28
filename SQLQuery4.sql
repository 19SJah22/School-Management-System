CREATE TABLE [dbo].[UserDetails]
(
	[Username] NVARCHAR (25) NOT NULL,
	[Password] NVARCHAR (25) NOT NULL,
	PRIMARY KEY CLUSTERED ([Password] ASC)
);