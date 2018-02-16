CREATE TABLE [dbo].[Employees]
(
	[EmployeeNo] INT NOT NULL PRIMARY KEY, 
    [Initials] NCHAR(3) NULL, 
    [FirstName] NCHAR(10) NULL, 
    [LastName] NCHAR(10) NULL, 
    [Identity] INT NOT NULL
)
