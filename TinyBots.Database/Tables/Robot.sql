CREATE TABLE [dbo].[Robot]
(
	[RobotId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Speed] INT NOT NULL, 
    [Damage] INT NOT NULL, 
    [Hitpoints] INT NOT NULL, 
    [Energy] INT NOT NULL, 
    [Image] NVARCHAR(50) NULL
)
