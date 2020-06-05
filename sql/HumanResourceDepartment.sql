CREATE DATABASE HumanResourcesDepartment
GO

USE HumanResourcesDepartment

CREATE TABLE Applicants (
	
	ID INT IDENTITY PRIMARY KEY,
	[LasrstName]		NVARCHAR(MAX)	NOT NULL,
	[FristName]			NVARCHAR(MAX)	NOT NULL,
	[MiddleName]		NVARCHAR(MAX)	NULL,
	[DateOfBirth]		DATE DEFAULT GETDATE() NOT NULL,
	[Gender]			NVARCHAR(20)	NOT NULL,
	[Series]			INT				NOT NULL,
	[Number]			INT				NOT NULL,
	[EmlpoymentDate]	DATETIME DEFAULT GETDATE() NOT NULL,
	[Education]			NVARCHAR(MAX)	NOT NULL,
	[TotalSalary]		FLOAT			NOT NULL,
	[Position]			INT				NOT NULL
)
GO


CREATE TABLE Postiton (

	ID INT IDENTITY PRIMARY KEY,
	[Title]		NVARCHAR(140)	NOT NULL,
	[Salary]	FLOAT			NOT NULL,
)
GO

CREATE TABLE Playments (

	ID INT IDENTITY PRIMARY KEY,
	[TitlePlayment]		NVARCHAR(140) NOT NULL,
	[SizeAmount]		FLOAT			NOT NULL
)
GO

CREATE TABLE Frames (
	
	ID INT IDENTITY PRIMARY KEY,
	[ApplicantsID]	INT NOT NULL,
	[PositionID]	INT NOT NULL,
	[PlaymentsID]	INT NOT NULL
)
GO

