CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Author] NVARCHAR(100) NOT NULL, 
    [Isbn] NVARCHAR(13) NULL, 
    [Genre] NVARCHAR(50) NULL, 
    [PageCount] INT NOT NULL, 
    [FriendLanded] NVARCHAR(100) NULL, 
    [Comments] NVARCHAR(500) NULL
)
