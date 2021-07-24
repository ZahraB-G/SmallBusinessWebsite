CREATE TABLE [dbo].[CompanyProfile]
(
	[CompanyId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyName] VARCHAR(50) NOT NULL, 
    [Address1] VARCHAR(100) NOT NULL, 
    [Address2] VARCHAR(100) NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(2) NOT NULL, 
    [ZipCode] VARCHAR(9) NOT NULL, 
    [UserCredentialsID] INT NOT NULL
)
