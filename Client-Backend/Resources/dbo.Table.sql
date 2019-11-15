CREATE TABLE [dbo].[Tasks]
(
	[TaskId] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(100) NOT NULL, 
    [Duration] TIME(0) NOT NULL,
	[UserId] INT NOT NULL, 
    CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([UserId] ASC, TaskId),
	CONSTRAINT [FK_User] FOREIGN KEY (UserId)
	REFERENCES [dbo].[User] (UserId)
);
