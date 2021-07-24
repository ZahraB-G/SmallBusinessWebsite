CREATE TABLE [dbo].[CustomerProfile]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Address1] VARCHAR(100) NULL, 
    [Address2] VARCHAR(100) NULL, 
    [City] VARCHAR(50) NULL, 
    [State] VARCHAR(2) NULL, 
    [Zipcode] VARCHAR(9) NULL, 
    [Email] VARCHAR(100) NULL, 
    [Phone] VARCHAR(10) NULL, 
    [UserCredentialsID] NCHAR(10) NOT NULL
)
