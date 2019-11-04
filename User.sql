CREATE TABLE [User].[Table]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [UserName] CHAR(15) NULL, 
    [EmailAddress] VARCHAR(100) NULL, 
    [PasswordSalt] CHAR(60) NULL, 
    [PasswordHash] CHAR(60) NULL, 
    [RelatedAccountID] NCHAR(10) NULL
)
